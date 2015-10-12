  _spBodyOnLoadFunctionNames.push('WaitForCalendarToLoad');
  var SEPARATOR = "|||";
  var SLASH = "/";

  function WaitForCalendarToLoad() {
      test = new String(window.location);
      tp1 = test.indexOf("sites");
      tp1 = test.substring(0, tp1);
      tp2 = tp1 + "sites" + SLASH + "oip";

    if (typeof SP.UI.ApplicationPages != 'undefined' && typeof SP.UI.ApplicationPages.CalendarNotify != 'undefined') {
        if (typeof SP.UI.ApplicationPages.CalendarNotify.$4a == 'undefined') {
            // post SP1
            var pwold$4b = SP.UI.ApplicationPages.CalendarNotify.$4b;
            SP.UI.ApplicationPages.CalendarNotify.$4b = function () {
                pwold$4b();
                ColorCalendar("1");
            };

            SP.UI.ApplicationPages.SummaryCalendarView.prototype.renderGrids = function ($p0) {
                var $v_0 = new Sys.StringBuilder();
                var $v_1 = $p0.length;
                for (var $v_2 = 0; $v_2 < $v_1; $v_2++) {
                    this.$7t_2($v_2, $p0[$v_2]);
                }
                for (var $v_3 = 0; $v_3 < $v_1; $v_3++) {
                    $v_0.append('<div>');
                    this.$I_2.$7o($v_0, $p0[$v_3], $v_3);
                    $v_0.append(this.emptY_DIV);
                    $v_0.append('</div>');
                }
                this.setInnerHtml($v_0.toString());
                ColorCalendar("2: " + $v_0.toString());
            };
        } else {
            // pre SP1
            var pwold$4a = SP.UI.ApplicationPages.CalendarNotify.$4a;
            
            SP.UI.ApplicationPages.CalendarNotify.$4a = function() {
                pwold$4a();
                ColorCalendar("3");
            };
            
            SP.UI.ApplicationPages.SummaryCalendarView.prototype.renderGrids = function($p0) {
                var $v_0 = new Sys.StringBuilder();
                var $v_1 = $p0.length;
                for (var $v_2 = 0; $v_2 < $v_1; $v_2++) {
                    this.$7r_2($v_2, $p0[$v_2]);
                }
                for (var $v_3 = 0; $v_3 < $v_1; $v_3++) {
                    $v_0.append('<div>');
                    this.$I_2.$7m($v_0, $p0[$v_3], $v_3);
                    $v_0.append(this.emptY_DIV);
                    $v_0.append('</div>');
                }
                this.setInnerHtml($v_0.toString());
                ColorCalendar("4");
            };
        }
    }
}

function ColorCalendar(z) {
    //alert(z);
    if (jQuery('a:contains(' + SEPARATOR + ')') != null) {

        var colorCodes = GetColorCodes();

        if (colorCodes == null) { alert('The color category list is empty.'); }

        jQuery('a:contains(' + SEPARATOR + ')').each(function () {
            var $box = jQuery(this).parents('div[title]');

            var fontColor;
            var backColor;

            if (colorCodes != null) {
                var colorList = GetColorCodeByCategory(colorCodes, GetCategory(this.innerHTML));

                if (colorList.length > 0) {
                    fontColor = colorList[0].fontColor.toString().toUpperCase() == "WHITE" ? "#FFF" : "#000";
                    backColor = colorList[0].hexColor;
                } else {
                    // Default to black font color
                    fontColor = "#000";
                    // Default to SharePoint color scheme for calendar item
                    backColor = "#DCFACF";
                }
            } else {
                // Default to black font color
                fontColor = "#000";
                // Default to SharePoint color scheme for calendar item
                backColor = "#DCFACF";
            }

            this.innerHTML = "<span style='font-weight:bold;color:" + fontColor + "'>" + GetActualText(this.innerHTML) + "</span>";

            jQuery($box).attr("title", GetActualText(jQuery($box).attr("title")));

            $box.css('background-color', backColor);
            $box.css('border', 'solid black 1px');
        });
    }
}

function GetActualText(originalText) {     
    var parts = originalText.split(SEPARATOR);
    return parts[0] + parts[2];   
}

function GetCategory(originalText) {
    var parts = originalText.split(SEPARATOR);
    return parts[1];   
}

jQuery.fn.filterNode = function (name) {
    return this.find('*').filter(function () {
        return this.nodeName == name;
    });
};

function GetColorCodeByCategory(colorCodes, category) {
    var colorList = [];

    for (var i = 0; i < colorCodes.length; i++) {
        if (colorCodes[i].category == category) {
            colorList.push(Color(colorCodes[i].category, colorCodes[i].hexColor, colorCodes[i].fontColor));
            break;
        }
    }

    return colorList;
}

function GetColorCodes() {
    //alert("Woohoo");
    var categoryList = "Colors";
    var colorCache = [];
    var query = "<Query><OrderBy><FieldRef Name='Title' Ascending='True'/></OrderBy></Query>";

    $().SPServices({
        operation: "GetListItems",
        async: false,
        listName: categoryList,
        webURL: tp2,
        CAMLViewFields: "<ViewFields properties='true'><FieldRef Name='Background' /><FieldRef Name='Title' /><FieldRef Name='Font' /></ViewFields>",
        CAMLQuery: query,
        completefunc: function (xData, status) {
            //if (status != "success")
            //alert(xData.responseXML.xml);

            $(xData.responseXML).find('*').filterNode('z:row').each(function () {
                //alert($(this).attr("ows_Background"));
                colorCache.push(Color($(this).attr("ows_Title"), $(this).attr("ows_Background"), $(this).attr("ows_Font")));
            });
        }
    });

    return colorCache;
}


function Color(category, hexColor, fontColor) {
    return { category: category, hexColor: hexColor, fontColor: fontColor };
}