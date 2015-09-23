using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.SharePoint.Administration;
using Microsoft.SharePoint.UserCode;
using System.Runtime.InteropServices;

namespace Solution_Validator
{
    [Guid("77899292-39AB-4742-B775-2C5ACA016BA4")]
    public class SolutionValidatorClass : SPSolutionValidator
    {
        const string validatorID = "42";

        public SolutionValidatorClass() { }

        public SolutionValidatorClass(SPUserCodeService service)
                :base(validatorID, service)
        {
            this.Signature = 1;
        }

        public override void ValidateSolution(SPSolutionValidationProperties properties)
        {
            foreach (SPSolutionFile file in properties.Files)
                if (file.Location.Contains(".jpg"))
                {
                    properties.Valid = false;
                    properties.ValidationErrorMessage = "Solution may not contain image";
                }
 
        }

        public override void ValidateAssembly(SPSolutionValidationProperties properties, SPSolutionFile assembly)
        {
            IReadOnlyCollection<byte> bytes = assembly.OpenBinary();

            if (bytes.LongCount() > 10000000)
            {
                properties.ValidationErrorMessage = "Assembly is too large";
                properties.Valid = false;
            }
        }
    }
}
