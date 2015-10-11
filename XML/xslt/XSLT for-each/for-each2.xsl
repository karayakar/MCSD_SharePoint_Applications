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
    <xsl:for-each select="catalog/cd[artist='Bob Dylan']">
    <tr>
      <td><xsl:value-of select="title"/></td>
      <td><xsl:value-of select="artist"/></td>
    </tr>
    </xsl:for-each>
  </table>
  </body>
  </html>
</xsl:template>

</xsl:stylesheet> 

<!-- 
    Note: The value of the select attribute is an XPath expression. An XPath expression works like navigating a file system; where a forward slash (/) selects subdirectories.

    Filtering the Output

    We can also filter the output from the XML file by adding a criterion to the select attribute in the <xsl:for-each> element.

    <xsl:for-each select="catalog/cd[artist='Bob Dylan']">

    Legal filter operators are:

        =  (equal)
        != (not equal)
        &lt; less than
        &gt; greater than

    Take a look at the adjusted XSL style sheet:
  -->