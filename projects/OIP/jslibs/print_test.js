$( "#print_cal" ).click(function() {	
  print_this();
});



function print_this() {

     var sURL = document.location.href;

     if (sURL.indexOf('?') > 0) {
         sURL = document.location + "&print_this";
     } else {
         sURL = document.location + "?print_this";
     }
     window.open(sURL);
 }

 // If we are in Print Preview Mode then Hide a bunch of styles.

 if (document.location.href.indexOf('print_this') > 0) {//if query string exists set core css classes to none
     //document.write('<style>');

     //document.write('.pa-printicon, .jm-toolbar, .ms-navframe,.ms-bannerframe,.ms-sbtable,.ms-searchform,.ms-sbtopcorner,.ms-sblbcornerumb,.ms-globalbreadcrumb,.ms-pagetitleareaframe table { display: none; } ');
     //document.write('div.ms-titleareaframe { border-top: 0px white solid; } ');

     //document.write('</style>');
     setTimeout(function(){  print(); }, 10000);//
     
 }
