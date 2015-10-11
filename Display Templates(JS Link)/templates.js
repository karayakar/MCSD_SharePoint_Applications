(function () {
	var context = {};
	context.Templates = {};
	context.Templates.Fields = {
		"Title": {
			"View": teamViewFiledTemplate,
			"DisplayForm": teamViewFiledTemplate,
			"NewForm": teamEditFiledTemplate,
			"EditForm": teamEditFiledTemplate

		}


	};
	SPClientTemplates.TemplateManager.RegisterTemplateOverrides(context);
})();

//This function provides the rendering logic for View and Display NewForm
function teamViewFiledTemplate(ctx){
	var team = ctx.CurrentItem[ctx.CurrentFieldSchema.Name];
	return "<div style='width: 200px...'"
}