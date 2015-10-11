 <?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">

<xsl:template match="/">
  <html>
  <body>
  <h2>My CD Collection</h2>
  <table border="1">
    <tr bgcolor="#9acd32">
      <th>Title</th>
      <th>Artist</th>
    </tr>
    <tr>
      <td>.</td>
      <td>.</td>
    </tr>
  </table>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet> 

<!-- 
  Example Explained

  Since an XSL style sheet is an XML document, it always begins with the XML declaration: <?xml version="1.0" encoding="UTF-8"?>.

  The next element, <xsl:stylesheet>, defines that this document is an XSLT style sheet document (along with the version number and XSLT namespace attributes).

  The <xsl:template> element defines a template. The match="/" attribute associates the template with the root of the XML source document.

  The content inside the <xsl:template> element defines some HTML to write to the output.

  The last two lines define the end of the template and the end of the style sheet.

  The result from this example was a little disappointing, because no data was copied from the XML document to the output. In the next chapter you will learn how to use the <xsl:value-of> element to select values from the XML elements.

  -->