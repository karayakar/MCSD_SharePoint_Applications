<xsl:stylesheet xmlns:x="http://www.w3.org/2001/XMLSchema" xmlns:d="http://schemas.microsoft.com/sharepoint/dsp" version="1.0" exclude-result-prefixes="xsl msxsl ddwrt" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime" xmlns:asp="http://schemas.microsoft.com/ASPNET/20" xmlns:__designer="http://schemas.microsoft.com/WebParts/v2/DataView/designer" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:msxsl="urn:schemas-microsoft-com:xslt" xmlns:SharePoint="Microsoft.SharePoint.WebControls" xmlns:ddwrt2="urn:frontpage:internal" xmlns:o="urn:schemas-microsoft-com:office:office"> 
  <xsl:include href="/_layouts/xsl/main.xsl"/> 
  <xsl:include href="/_layouts/xsl/internal.xsl"/> 
  	<xsl:param name="AllRows" select="/dsQueryResponse/Rows/Row[$EntityName = '' or (position() &gt;= $FirstRow and position() &lt;= $LastRow)]"/>
  	<xsl:param name="dvt_apos">&apos;</xsl:param>
	<xsl:param name="Today">CurrentDate</xsl:param>
	<xsl:template name="View_Default_RootTemplate" mode="RootTemplate" match="View" ddwrt:dvt_mode="root" ddwrt:ghost="" xmlns:ddwrt2="urn:frontpage:internal">
    	<xsl:param name="ShowSelectAllCheckbox" select="'True'"/>
    	<xsl:if test="($IsGhosted = '0' and $MasterVersion=3 and Toolbar[@Type='Standard']) or $ShowAlways">
      		<xsl:call-template name="ListViewToolbar"/>
    </xsl:if>
    <table width="100%" cellspacing="0" cellpadding="0" border="0">
      	<xsl:if test="not($NoCTX)">
        	<xsl:call-template name="CTXGeneration"/>
      </xsl:if>
      	<xsl:if test="List/@TemplateType=109">
        	<xsl:call-template name="PicLibScriptGeneration"/>
      </xsl:if>
      <tr>
        <td>
          	<xsl:if test="not($NoAJAX)">
            <iframe src="javascript:false;" id="FilterIframe{$ViewCounter}" name="FilterIframe{$ViewCounter}" style="display:none" height="0" width="0" FilterLink="{$FilterLink}"></iframe>
          </xsl:if>
          <table summary="{List/@title} {List/@description}" o:WebQuerySourceHref="{$HttpPath}&amp;XMLDATA=1&amp;RowLimit=0&amp;View={$View}" 
                          width="100%" border="0" cellspacing="0" dir="{List/@Direction}">
            <xsl:if test="not($NoCTX)">
              	<xsl:attribute name="onmouseover">EnsureSelectionHandler(event,this,<xsl:value-of select ="$ViewCounter"/>)</xsl:attribute>
            </xsl:if>
            <xsl:if test="$NoAJAX">
              	<xsl:attribute name="FilterLink">
                <xsl:value-of select="$FilterLink"/>
              </xsl:attribute>
            </xsl:if>
            <xsl:attribute name="cellpadding">
              	<xsl:choose>
                	<xsl:when test="ViewStyle/@ID='15' or ViewStyle/@ID='16'">0</xsl:when>
                	<xsl:otherwise>1</xsl:otherwise>
              	</xsl:choose>
            </xsl:attribute>
            <xsl:attribute name="id">
              	<xsl:choose>
                	<xsl:when test="$IsDocLib or dvt_RowCount = 0">onetidDoclibViewTbl0</xsl:when>
                	<xsl:otherwise>
                  <xsl:value-of select="concat($List, '-', $View)"/>
                </xsl:otherwise>
              	</xsl:choose>
            </xsl:attribute>
            <xsl:attribute name="class">
              	<xsl:choose>
                	<xsl:when test="ViewStyle/@ID='0' or ViewStyle/@ID='17'"><xsl:value-of select="$ViewClassName"/> ms-basictable</xsl:when>
                	<xsl:when test="ViewStyle/@ID='16'"><xsl:value-of select="$ViewClassName"/> ms-listviewtable2</xsl:when>
                	<xsl:otherwise><xsl:value-of select="$ViewClassName"/></xsl:otherwise>
              	</xsl:choose>
            </xsl:attribute>
            <xsl:if test="$InlineEdit">
              	<xsl:attribute name="inlineedit">javascript: <xsl:value-of select="ddwrt:GenFireServerEvent('__cancel;dvt_form_key={@ID}')"/>;CoreInvoke(&apos;ExpGroupOnPageLoad&apos;, &apos;true&apos;);</xsl:attribute>
            </xsl:if>
            <xsl:apply-templates select="." mode="full">
              	<xsl:with-param name="ShowSelectAllCheckbox" select="$ShowSelectAllCheckbox"/>
            </xsl:apply-templates>
          </table>
              <xsl:choose>
                <xsl:when test="$IsDocLib or dvt_RowCount = 0"><script type='text/javascript'>HideListViewRows("onetidDoclibViewTbl0");</script></xsl:when>
                <xsl:otherwise>
                  <script type='text/javascript'><xsl:value-of select="concat('HideListViewRows(&quot;', $List, '-', $View, '&quot;);')" /></script>
                </xsl:otherwise>
              </xsl:choose>
        </td>
      </tr>
      	<xsl:if test="$dvt_RowCount = 0 and not (@BaseViewID='3' and List/@TemplateType='102')">
        <tr>
          <td>
             <table width="100%" border="0" dir="{List/@Direction}">
               	<xsl:call-template name="EmptyTemplate" />
             </table>
          </td>
        </tr>
      </xsl:if>
    </table>
    	<xsl:call-template name="pagingButtons" />
    	<xsl:if test="Toolbar[@Type='Freeform'] or ($MasterVersion=4 and Toolbar[@Type='Standard'])">
      		<xsl:call-template name="Freeform">
        		<xsl:with-param name="AddNewText">
          			<xsl:choose>
            			<xsl:when test="List/@TemplateType='104'">
              <xsl:value-of select="'Add new announcement'"/>
            </xsl:when>
            			<xsl:when test="List/@TemplateType='101' or List/@TemplateType='115'">
              <xsl:value-of select="'Add document'"/>
            </xsl:when>
            			<xsl:when test="List/@TemplateType='103'">
              <xsl:value-of select="'Add new link'"/>
            </xsl:when>
            			<xsl:when test="List/@TemplateType='106'">
              <xsl:value-of select="'Add new event'"/>
            </xsl:when>
            			<xsl:when test="List/@TemplateType='119'">
              <xsl:value-of select="'Add new page'"/>
            </xsl:when>
            			<xsl:otherwise>
              <xsl:value-of select="'Add new item'"/>
            </xsl:otherwise>
          			</xsl:choose>
        </xsl:with-param>
        		<xsl:with-param name="ID">
          			<xsl:choose>
          				<xsl:when test="List/@TemplateType='104'">idHomePageNewAnnouncement</xsl:when>
          				<xsl:when test="List/@TemplateType='101'">idHomePageNewDocument</xsl:when>
          				<xsl:when test="List/@TemplateType='103'">idHomePageNewLink</xsl:when>
          				<xsl:when test="List/@TemplateType='106'">idHomePageNewEvent</xsl:when>
          				<xsl:when test="List/@TemplateType='119'">idHomePageNewWikiPage</xsl:when>
          				<xsl:otherwise>idHomePageNewItem</xsl:otherwise>
          			</xsl:choose>
        </xsl:with-param>
      		</xsl:call-template>
    </xsl:if>
  </xsl:template>
	
	
	
	<xsl:template name="dvt_headerfield.Institutions" ddwrt:dvt_mode="header" ddwrt:ghost="" xmlns:ddwrt2="urn:frontpage:internal">
		
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname"  />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:variable name="separator" select="' '" />
    	<xsl:variable name="connector" select="';'" />
    	<xsl:variable name="linkdir">
      		<xsl:choose>
        		<xsl:when test="$dvt_sortfield = $fieldname and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
        		<xsl:otherwise>Asc</xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:variable name="jsescapeddisplayname">
      		<xsl:call-template name="fixQuotes">
        		<xsl:with-param name="string" select="$displayname"/>
      		</xsl:call-template>
    </xsl:variable>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="$MasterVersion=4 and not($NoAJAX)">
        <div Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
             DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
             class="ms-vh-div">
          	<xsl:call-template name="headerfield.Institutions">
            	<xsl:with-param name="fieldname" select ="$fieldname" />
            	<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
            	<xsl:with-param name="displayname" select="$displayname" />
            	<xsl:with-param name="fieldtype" select="$fieldtype"/>
          	</xsl:call-template>
        	
        	
        	
        	
        	
        	
        	
        </div>
      			<xsl:if test="(not($sortable='FALSE') and not(@FieldType='MultiChoice')) or (not(@Filterable='FALSE') and not(@FieldType='Note') and not(@FieldType='URL'))">
        <div class="s4-ctx" style="left: 149px; top: 39px">
          <span>&#160;</span>
            <a onfocus="OnChildColumn(this.parentNode.parentNode); return false;" onclick="PopMenuFromChevron(event); return false;" href="javascript:;" title="{$open_menu}">
            </a>
          <span>&#160;</span>
        </div>
      </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:attribute name="style">padding:0 !important;border:0 !important;</xsl:attribute>
        <div style="width:100%;position:relative;left:0;top:0;margin:0;border:0">
          	<xsl:choose>
            	<xsl:when test="$NoAJAX">
              <table CtxNum="{$ViewCounter}" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" name="{$fieldname}" DisplayName="{$displayname}" height="100%">
                <xsl:choose>
                  	<xsl:when test="$MasterVersion=4">
                    	<xsl:attribute name="style">width:100%;height:27px</xsl:attribute>
                  </xsl:when>
                  	<xsl:otherwise>
                    	<xsl:attribute name="style">width:100%</xsl:attribute>
                  </xsl:otherwise>
                </xsl:choose>
                <xsl:if test="$sortable='FALSE'">
                  	<xsl:attribute name="Sortable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@Filterable='FALSE'">
                  	<xsl:attribute name="Filterable">FALSE</xsl:attribute>
                </xsl:if>
                <xsl:if test="@FilterDisableMessage">
                  	<xsl:attribute name="FilterDisableMessage">
                    <xsl:value-of select="@FilterDisableMessage" />
                  </xsl:attribute>
                </xsl:if>
                <xsl:if test="not($sortable='FALSE') or not(@Filterable='FALSE')">
                  	<xsl:attribute name="onmouseover">
                    	<xsl:text disable-output-escaping="yes">OnMouseOverAdHocFilter(this, &apos;</xsl:text>
                    <xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" />
                    	<xsl:text disable-output-escaping="yes">&apos; , &apos;&apos;, &apos;&apos;)</xsl:text>
                  </xsl:attribute>
                  	<xsl:attribute name="SortFields"><xsl:value-of select="concat($RootFolderParam,$FieldSortParam,'SortField=',@Name,'&amp;SortDir=',$linkdir)"/></xsl:attribute>
                  	<xsl:attribute name="FieldType"><xsl:value-of select="@FieldType"/></xsl:attribute>
                  	<xsl:attribute name="ResultType"><xsl:value-of select="@ResultType"/></xsl:attribute>
                </xsl:if>
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:when>
            	<xsl:otherwise>
              <table style="width:100%;" Sortable="{$sortable}" SortDisable="" FilterDisable="" Filterable="{@Filterable}" FilterDisableMessage="{@FilterDisableMessage}" name="{@Name}" CTXNum="{$ViewCounter}"
                 DisplayName="{@DisplayName}" FieldType="{@FieldType}" ResultType="{@ResultType}" SortFields="{$RootFolderParam}{$FieldSortParam}SortField={@Name}&amp;SortDir={$linkdir}"
                 height="100%" cellspacing="1" cellpadding="0" class="ms-unselectedtitle" onmouseover="OnMouseOverFilter(this)">
                <xsl:call-template name="headerFieldRow">
                  	<xsl:with-param name="fieldname" select="$fieldname"/>
                  	<xsl:with-param name="fieldtitle" select ="$fieldtitle"/>
                  	<xsl:with-param name="displayname" select="$displayname"/>
                  	<xsl:with-param name="fieldtype" select ="$fieldtype"/>
                </xsl:call-template>
              </table>
            </xsl:otherwise>
          	</xsl:choose>
        </div>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	
	<xsl:template name="GroupTemplate" ddwrt:ghost="" xmlns:ddwrt2="urn:frontpage:internal">
    	<xsl:param name="Groups" select="."/>
    	<xsl:param name="Collapse" select="."/>
    	<xsl:param name="HasExtraColumn" select="false()"/>
    	<xsl:if test="position() = 1">
      <input type="hidden" id="GroupByColFlag"/>
      <input type="hidden" id="GroupByWebPartID{$ViewCounter}" webPartID="{$View}"/>
      <tbody id="GroupByCol{$View}">
        <tr id="GroupByCol{$ViewCounter}" queryString ="{$FilterLink}"/>
      </tbody >
    </xsl:if>
		<xsl:if test="../../@ViewStyleID='6'">
      <script type="text/javascript">
        fIsInGroupByView = true;
      </script>
	</xsl:if>
    	<xsl:choose>
      		<xsl:when test="../../@ViewStyleID='20'">
        <script type="text/javascript">
          ppt = document.getElementById('previewpanetable<xsl:value-of select ="$ViewCounter"/>');
          ppt.style.display = "none";
          ppe = document.getElementById('previewpaneerror<xsl:value-of select ="$ViewCounter"/>');
          ppe.innerHTML = "<xsl:value-of select ='&#039;The preview pane view style cannot be used with grouped views.&#039;'/>";
        </script>
        </xsl:when>
      		<xsl:otherwise>
        		<xsl:variable name="expandImage">
          			<xsl:choose>
            			<xsl:when test="$Collapse">/_layouts/images/plus.gif</xsl:when>
            			<xsl:otherwise>/_layouts/images/minus.gif</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="expandText">
          			<xsl:choose>
            			<xsl:when test="$Collapse">
              <xsl:value-of select="'collapse'"/>
            </xsl:when>
            			<xsl:otherwise>
              <xsl:value-of select="'expand'"/>
            </xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:choose>
          			<xsl:when test="count($Groups) = 2">
            			<xsl:variable name="fieldtitle" select="$Groups[1]/@Name"/>
            			<xsl:variable name="fieldtitle2" select="$Groups[2]/@Name"/>
            			<xsl:choose>
              				<xsl:when test="@*[name() = concat($fieldtitle, '.newgroup')] = '1'">
                				<xsl:call-template name="GroupHeader">
                  					<xsl:with-param name="fieldtitle" select="$fieldtitle"/>
                  					<xsl:with-param name="fieldname" select="$Groups[1]/@DisplayName"/>
                  					<xsl:with-param name="group" select="$Groups[1]"/>
                  					<xsl:with-param name="fieldtype" select="$Groups[1]/@Type"/>
                  					<xsl:with-param name="groupid" select="'0'" />
                  					<xsl:with-param name="imagesrc" select="$expandImage"/>
                  					<xsl:with-param name="alttext">
                    <xsl:value-of select="'collapse'"/>
                  </xsl:with-param>
                  					<xsl:with-param name="altname">
                    <xsl:value-of select="'expand'"/>
                  </xsl:with-param>
                  					<xsl:with-param name="RowCount" select="@*[name() = concat($fieldtitle, '.COUNT.group')]"/>
                  					<xsl:with-param name="groupindex" select="@*[name() = concat($fieldtitle, '.groupindex')]"/>
                				</xsl:call-template>
                				<xsl:if test="$XmlDefinition/Aggregations/FieldRef">
                  <tbody id="aggr{$ViewCounter}-{@*[name() = concat($fieldtitle, '.groupindex')]}_">
                    <xsl:if test="$Collapse">
                      	<xsl:attribute name="style">display:none</xsl:attribute>
                    </xsl:if>
                    <tr>
                      	<xsl:if test="$HasExtraColumn">
                        <td/>
                      </xsl:if>
                      	<xsl:if test="$InlineEdit">
                        <td width="1%"/>
                      </xsl:if >
                      <xsl:apply-templates mode="aggregate" select="$XmlDefinition/ViewFields/FieldRef[not(@Explicit='TRUE')]">
                        <xsl:with-param name="Rows" select="."/>
                        <xsl:with-param name="GroupLevel" select="1"/>
                      </xsl:apply-templates>
                    </tr>
                  </tbody>
                </xsl:if>
                				<xsl:call-template name="GroupHeader">
                  					<xsl:with-param name="fieldtitle" select="$fieldtitle2"/>
                  					<xsl:with-param name="fieldname" select="$Groups[2]/@DisplayName"/>
                  					<xsl:with-param name="group" select="$Groups[2]"/>
                  					<xsl:with-param name="fieldtype" select="$Groups[2]/@Type"/>
                  					<xsl:with-param name="groupid" select="'1'" />
                  					<xsl:with-param name="imagesrc" select="$expandImage" />
                  					<xsl:with-param name="alttext">
                    					<xsl:choose>
                      						<xsl:when test="$Collapse">
                        <xsl:value-of select="'expand'"/>
                      </xsl:when>
                      						<xsl:otherwise>
                        <xsl:value-of select="'collapse'"/>
                      </xsl:otherwise>
                    					</xsl:choose>
                  </xsl:with-param>
                  					<xsl:with-param name="altname" select="$expandText"/>
                  					<xsl:with-param name="RowCount" select="@*[name() = concat($fieldtitle2, '.COUNT.group2')]"/>
                  					<xsl:with-param name="Collapse" select="$Collapse"/>
                  					<xsl:with-param name="groupindex" select="@*[name() = concat($fieldtitle, '.groupindex')]"/>
                  					<xsl:with-param name="groupindex2" select="@*[name() = concat($fieldtitle2, '.groupindex2')]"/>
                				</xsl:call-template>
                				<xsl:if test="$XmlDefinition/Aggregations/FieldRef">
                  <tbody id="aggr{$ViewCounter}-{@*[name() = concat($fieldtitle, '.groupindex')]}{@*[name() = concat($fieldtitle2, '.groupindex2')]}_">
                    <xsl:if test="$Collapse">
                      	<xsl:attribute name="style">display:none</xsl:attribute>
                    </xsl:if>
                    <tr>
                      	<xsl:if test="$HasExtraColumn">
                        <td/>
                      </xsl:if>
                      	<xsl:if test="$InlineEdit">
                        <td width="1%"/>
                      </xsl:if >
                      <xsl:apply-templates mode="aggregate" select="$XmlDefinition/ViewFields/FieldRef[not(@Explicit='TRUE')]">
                        <xsl:with-param name="Rows" select="."/>
                        <xsl:with-param name="GroupLevel" select="2"/>
                      </xsl:apply-templates>
                    </tr>
                  </tbody>
                </xsl:if>
                				<xsl:call-template name="NewTBody">
                  					<xsl:with-param name="groupindex" select="@*[name() = concat($fieldtitle, '.groupindex')]"/>
                  					<xsl:with-param name="groupindex2" select="@*[name() = concat($fieldtitle2, '.groupindex2')]"/>
                  					<xsl:with-param name="Collapse" select="$Collapse"/>
                				</xsl:call-template>
              </xsl:when>
              				<xsl:when test="@*[name() = concat($fieldtitle2, '.newgroup')] = '1'">
                				<xsl:call-template name="GroupHeader">
                  					<xsl:with-param name="fieldtitle" select="$fieldtitle2"/>
                  					<xsl:with-param name="fieldname" select="$Groups[2]/@DisplayName"/>
                  					<xsl:with-param name="group" select="$Groups[2]"/>
                  					<xsl:with-param name="fieldtype" select="$Groups[2]/@Type"/>
                  					<xsl:with-param name="groupid" select="'1'" />
                  					<xsl:with-param name="imagesrc" select="$expandImage" />
                  					<xsl:with-param name="alttext">
                    					<xsl:choose>
                      						<xsl:when test="$Collapse">
                        <xsl:value-of select="'expand'"/>
                      </xsl:when>
                      						<xsl:otherwise>
                        <xsl:value-of select="'collapse'"/>
                      </xsl:otherwise>
                    					</xsl:choose>
                  </xsl:with-param>
                  					<xsl:with-param name="altname" select="$expandText"/>
                  					<xsl:with-param name="RowCount" select="@*[name() = concat($fieldtitle2, '.COUNT.group2')]"/>
                  					<xsl:with-param name="Collapse" select="$Collapse"/>
                  					<xsl:with-param name="groupindex" select="@*[name() = concat($fieldtitle, '.groupindex')]"/>
                  					<xsl:with-param name="groupindex2" select="@*[name() = concat($fieldtitle2, '.groupindex2')]"/>
                				</xsl:call-template>
                				<xsl:if test="$XmlDefinition/Aggregations/FieldRef">
                  <tbody id="aggr{$ViewCounter}-{@*[name() = concat($fieldtitle, '.groupindex')]}{@*[name() = concat($fieldtitle2, '.groupindex2')]}_">
                    <xsl:if test="$Collapse">
                      	<xsl:attribute name="style">display:none</xsl:attribute>
                    </xsl:if>
                    <tr>
                      	<xsl:if test="$HasExtraColumn">
                        <td/>
                      </xsl:if>
                      	<xsl:if test="$InlineEdit">
                        <td width="1%"/>
                      </xsl:if >
                      <xsl:apply-templates mode="aggregate" select="$XmlDefinition/ViewFields/FieldRef[not(@Explicit='TRUE')]">
                        <xsl:with-param name="Rows" select="."/>
                        <xsl:with-param name="GroupLevel" select="2"/>
                      </xsl:apply-templates>
                    </tr>
                  </tbody>
                </xsl:if>
                				<xsl:call-template name="NewTBody">
                  					<xsl:with-param name="groupindex" select="@*[name() = concat($fieldtitle, '.groupindex')]"/>
                  					<xsl:with-param name="groupindex2" select="@*[name() = concat($fieldtitle2, '.groupindex2')]"/>
                  					<xsl:with-param name="Collapse" select="$Collapse"/>
                				</xsl:call-template>
              </xsl:when>
            			</xsl:choose>
          </xsl:when>
          			<xsl:when test="count($Groups) = 1">
            			<xsl:variable name="fieldtitle" select="$Groups/@Name"/>
            			<xsl:if test="@*[name() = concat($fieldtitle, '.newgroup')] = '1'">
              				<xsl:call-template name="GroupHeader">
                				<xsl:with-param name="fieldtitle">
                  <xsl:value-of select="$fieldtitle"/>
                </xsl:with-param>
                				<xsl:with-param name="fieldname">
                  <xsl:value-of select="$Groups/@DisplayName"/>
                </xsl:with-param>
                				<xsl:with-param name="group" select="$Groups[1]"/>
                				<xsl:with-param name="fieldtype">
                  <xsl:value-of select="$Groups/@Type"/>
                </xsl:with-param>
                				<xsl:with-param name="groupid" select="'0'" />
                				<xsl:with-param name="imagesrc" select="$expandImage" />
                				<xsl:with-param name="alttext">
                  					<xsl:choose>
                    					<xsl:when test="$Collapse">
                      <xsl:value-of select="'expand'"/>
                    </xsl:when>
                    					<xsl:otherwise>
                      <xsl:value-of select="'collapse'"/>
                    </xsl:otherwise>
                  					</xsl:choose>
                </xsl:with-param>
                				<xsl:with-param name="altname" select="$expandText"/>
                				<xsl:with-param name="RowCount" select="@*[name() = concat($fieldtitle, '.COUNT.group')]"/>
                				<xsl:with-param name="groupindex" select="@*[name() = concat($fieldtitle, '.groupindex')]"/>
              				</xsl:call-template>
              				<xsl:if test="$XmlDefinition/Aggregations/FieldRef">
                <tbody id="aggr{$ViewCounter}-{@*[name() = concat($fieldtitle, '.groupindex')]}_">
                  	<xsl:if test="$Collapse">
                    	<xsl:attribute name="style">display:none</xsl:attribute>
                  </xsl:if>
                  <tr>
                    <xsl:if test="$HasExtraColumn">
                      <td/>
                    </xsl:if>
                    <xsl:if test="$InlineEdit">
                      <td width="1%"/>
                    </xsl:if >
                    <xsl:apply-templates mode="aggregate" select="$XmlDefinition/ViewFields/FieldRef[not(@Explicit='TRUE')]">
                      	<xsl:with-param name="Rows" select="."/>
                      	<xsl:with-param name="GroupLevel" select="1"/>
                    </xsl:apply-templates>
                  </tr>
                </tbody>
              </xsl:if>
              				<xsl:call-template name="NewTBody">
                				<xsl:with-param name="groupindex" select="@*[name() = concat($fieldtitle, '.groupindex')]"/>
                				<xsl:with-param name="Collapse" select="$Collapse"/>
              				</xsl:call-template>
            </xsl:if>
          </xsl:when>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
  </xsl:template>
	
	
	<xsl:template name="FieldRef_printTableCell_EcbAllowed.Institutions" match="FieldRef[@Name='Institutions']" mode="printTableCellEcbAllowed" ddwrt:dvt_mode="body" ddwrt:ghost="" xmlns:ddwrt2="urn:frontpage:internal">
    	<xsl:param name="thisNode" select="."/>
    	<xsl:param name="class" />
    <td>
		<xsl:attribute name="style">
			<xsl:if test="normalize-space($thisNode/@Institution) = 'TRADOC Institution'" ddwrt:cf_explicit="1" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime">border: thin solid #000000; background-color: #00BFFF; font-weight: normal; color: #000000;</xsl:if>
			
			<xsl:if test="normalize-space($thisNode/@Institution) = 'Non-TRADOC Institution'" ddwrt:cf_explicit="1" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime">border: thin solid #000000; background-color: #EEE8AA; font-weight: normal; color: #000000;</xsl:if>
			
			<xsl:if test="normalize-space($thisNode/@Institution) = 'Stand Alone NCOAs'" ddwrt:cf_explicit="1" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime">border: thin solid #000000; background-color: #E9967A; font-weight: normal; color: #000000;</xsl:if>
			
			<xsl:if test="normalize-space($thisNode/@Institution) = 'OIP'" ddwrt:cf_explicit="1" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime">border: thin solid #000000; background-color: #DDA0DD; color: #000000;</xsl:if>
			
			<xsl:if test="normalize-space($thisNode/@Institution) = 'Proponent'" ddwrt:cf_explicit="1" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime">border: thin solid #000000; background-color: #D3D3D3; color: #000000;</xsl:if>
			
			<xsl:if test="normalize-space($thisNode/@Institution) = 'RC Institution'" ddwrt:cf_explicit="1" xmlns:ddwrt="http://schemas.microsoft.com/WebParts/v2/DataView/runtime">border: thin solid #000000; background-color: #7CFC00; color: #000000;</xsl:if>
			
		</xsl:attribute>
		
		<xsl:if test="@ClassInfo='Menu' or @ListItemMenu='TRUE'">
        	<xsl:attribute name="height">100%</xsl:attribute>
        	<xsl:attribute name="onmouseover">OnChildItem(this)</xsl:attribute>
      </xsl:if>
      	<xsl:attribute name="class">
        	<xsl:call-template name="getTDClassValue">
          		<xsl:with-param name="class" select="$class" />
          		<xsl:with-param name="Type" select="@Type"/>
          		<xsl:with-param name="ClassInfo" select="@ClassInfo"/>
        	</xsl:call-template>
      </xsl:attribute>
      <xsl:apply-templates select="." mode="PrintFieldWithECB">
        <xsl:with-param name="thisNode" select="$thisNode"/>
      </xsl:apply-templates>
    </td>
  </xsl:template>
	
	
	
	
	
	
	
	
	
	<xsl:template name="FieldHeader" ddwrt:dvt_mode="header" ddwrt:ghost="">
    	<xsl:param name="fieldname" />
    	<xsl:param name="fieldtitle" />
    	<xsl:param name="displayname" />
    	<xsl:param name="fieldtype" select="'0'"/>
    	<xsl:param name="thisNode" select="."/>
    	<xsl:variable name="sortable">
      		<xsl:choose>
        		<xsl:when test="../../@BaseViewID='3' and ../../List/@TemplateType='106'">FALSE</xsl:when>
        		<xsl:otherwise>
          <xsl:value-of select="./@Sortable"/>
        </xsl:otherwise>
      		</xsl:choose>
    </xsl:variable>
    	<xsl:choose>
      		<xsl:when test="not($sortable='FALSE')">
        		<xsl:variable name="sortfield">
          			<xsl:choose>
            			<xsl:when test="substring($fieldname, string-length($fieldname) - 5) = '(text)'">
              <xsl:value-of select="substring($fieldname, 1, string-length($fieldname) - 6)" />
            </xsl:when>
            			<xsl:otherwise>
              <xsl:value-of select="$fieldname"/>
            </xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="linkdir">
          			<xsl:choose>
            			<xsl:when test="$dvt_sortfield = $sortfield and ($dvt_sortdir = 'ascending' or $dvt_sortdir = 'ASC')">Desc</xsl:when>
            			<xsl:otherwise>Asc</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="sortText">
          			<xsl:choose>
            			<xsl:when test="$linkdir='Desc'">&apos; + &apos;descending&apos; + &apos;</xsl:when>
            			<xsl:otherwise>&apos; + &apos;ascending&apos; + &apos;</xsl:otherwise>
          			</xsl:choose>
        </xsl:variable>
        		<xsl:variable name="jsescapeddisplayname">
          			<xsl:call-template name="fixQuotes">
            			<xsl:with-param name="string" select="$displayname"/>
          			</xsl:call-template>
        </xsl:variable>
        		<xsl:variable name="separator" select="' '" />
        		<xsl:variable name="connector" select="';'" />
        <a id="diidSort{$fieldname}" onfocus="OnFocusFilter(this)">
          		<xsl:attribute name="href">javascript: <xsl:if test="$NoAJAX">
              		<xsl:call-template name="GenFireServerEvent">
                		<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                		<xsl:with-param name="apos">&apos;</xsl:with-param>
              		</xsl:call-template>
            </xsl:if>
          </xsl:attribute>
          		<xsl:attribute name="onclick">
            		<xsl:choose>
              			<xsl:when test="not($NoAJAX)">javascript:return OnClickFilter(this,event);</xsl:when>
              			<xsl:otherwise>javascript: <xsl:call-template name="GenFireServerEvent">
                  			<xsl:with-param name="param" select="concat('dvt_sortfield={',$sortfield,'};dvt_sortdir={',$sortText,'}')"/>
                  			<xsl:with-param name="apos">&apos;</xsl:with-param>
                			</xsl:call-template>; event.cancelBubble = true; return false;</xsl:otherwise>
            		</xsl:choose>
          </xsl:attribute>
          		<xsl:choose>
            		<xsl:when test="not($NoAJAX)">
              			<xsl:attribute name="SortingFields"><xsl:value-of select ="$RootFolderParam"/><xsl:value-of select ="$FieldSortParam"/>SortField=<xsl:value-of select="@Name"/>&amp;SortDir=<xsl:value-of select="$linkdir"/></xsl:attribute>
            </xsl:when>
            		<xsl:otherwise>
              			<xsl:attribute name="FilterString"><xsl:value-of select="concat($jsescapeddisplayname,$separator,$fieldname, $separator,$fieldtype, $connector, $LCID, $separator, $WebPartClientID)" /></xsl:attribute>
            </xsl:otherwise>
          		</xsl:choose>
          		<xsl:choose>
            		<xsl:when test="$fieldtype = 'Attachments'">
              <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
            </xsl:when>
            		<xsl:otherwise>
              <span><xsl:value-of select="$fieldtitle" /></span></xsl:otherwise>
          		</xsl:choose>
          		<xsl:if test="$dvt_sortfield = $sortfield">
            		<xsl:choose>
              			<xsl:when test="$dvt_sortdir = 'ascending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortAsc}" src="{ddwrt:FieldSortImageUrl('Desc')}" />
              </xsl:when>
              			<xsl:when test="$dvt_sortdir = 'descending'">
                <img border="0" alt="{$Rows/@viewedit_onetidSortDesc}" src="{ddwrt:FieldSortImageUrl('Asc')}" />
              </xsl:when>
            		</xsl:choose>
          </xsl:if>
          <img src="/_layouts/images/blank.gif" class="ms-hidden" border="0" width="1" height="1" alt=""/>
        </a>
        <img src="/_layouts/images/blank.gif" alt="" border="0"/>
        		<xsl:choose>
          			<xsl:when test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
            <img src="/_layouts/images/filter.gif" border="0" alt="" />
          </xsl:when>
          			<xsl:otherwise>
            <img src="/_layouts/images/blank.gif" border="0" alt=""/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:when>
      		<xsl:when test="not(@Filterable='FALSE') and ($sortable='FALSE')">
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
        		<xsl:if test="contains($dvt_filterfields, concat(';', $fieldname, ';' )) or contains($dvt_filterfields, concat(';@', $fieldname, ';' ))">
          <img src="/_layouts/images/filter.gif" border="0" alt="" />
        </xsl:if>
      </xsl:when>
      		<xsl:otherwise>
        		<xsl:choose>
          			<xsl:when test="$fieldtype = 'Attachments'">
            <xsl:value-of select="$fieldtitle" disable-output-escaping="yes"/>
          </xsl:when>
          			<xsl:otherwise>
            <xsl:value-of select="$fieldtitle"/>
          </xsl:otherwise>
        		</xsl:choose>
      </xsl:otherwise>
    	</xsl:choose>
    	<xsl:if test="($fieldtype='BusinessData') and not($XmlDefinition/List/@ExternalDataList='1')">
      <a style="padding-left:2px;padding-right:12px" onmouseover="" onclick="GoToLink(this);return false;"
        href="{$HttpVDir}/_layouts/BusinessDataSynchronizer.aspx?ListId={$List}&amp;ColumnName={$fieldname}">
        <img border="0" src="/_layouts/images/bdupdate.gif" alt="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}" title="{$Rows/@resource.wss.BusinessDataField_UpdateImageAlt}"/>
      </a>
    </xsl:if>
  </xsl:template>	
	</xsl:stylesheet>
