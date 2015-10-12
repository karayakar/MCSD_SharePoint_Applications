
//Using using
using(site = new SPSite("http://domain.com"))
	using(web = site.RootWeb)
	{
		lstProperties.Items.Add("Url: " + web.Url);
		lstProperties.Items.Add("Title: " + web.Title);
		lstProperties.Items.Add("Description: " + web.Properties);
	}

	//using disposal();
	private void usingDisposal()
	{
		site = new SPSite("http://domain.com");

		site.Disposal
	}

