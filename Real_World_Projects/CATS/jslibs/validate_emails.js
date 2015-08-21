var validate_email = function(){
	
		//check if JavaScript is Enabled
		
		//get dom ref
		var dom_ref = $('#ctl00_m_g_b2ad0a2e_ad9d_4aea_aa7b_1d5cd7127a0e_ff21_ctl00_ctl00_TextField');
		var open_email = true;
		
		//ref email contacts text field
		var text_field = $('#ctl00_m_g_b2ad0a2e_ad9d_4aea_aa7b_1d5cd7127a0e_ff21_ctl00_ctl00_TextField').text();
		
		
		//get string array
		var arr = text_field.split(';');
		
		//validate emails
		for( var i = 0, count = arr.length; i < count; i++ ){
			var str = arr[i];
			var patt = /^\s*[\w\-\+_]+(\.[\w\-\+_]+)*\@[\w\-\+_]+\.[\w\-\+_]+(\.[\w\-\+_]+)*\s*$/;
			var res = patt.test(str);
			
			if(!res){//inform users to check emails
				open_email = false;
				alert(' Check Syntax Near  --> ' + arr[i-1] );	
			}
		}//end for()
		
		if(open_email){//open client email
			window.location.href =  'mailto:' + dom_ref.html() + '?subject=Test Email via Tasking Units&body=Testing%20Email%20Through%20Tasking' + "%20Units List.";
		}
}//end validate_email()