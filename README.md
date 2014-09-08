FeedParser
==========

Quickly read Wordpress or any RSS/Atom feed in C#

Use
-------------
```
public ActionResult Index(int page = 1, int? year = null, int? month = null)
{
	var posts = new List<BlogPost>();

	var monthLimit = false;
	var monthFilter = "";
	if (year != null && month != null)
	{
		monthLimit = true;
		monthFilter = string.Format("{0}/{1}/", year, month);
	}
	else
	{
		monthFilter = "page";
	}

	var doPage = false;	
	if (page != 1)
		doPage = true;
        
	var parser = new FeedParser();

	var url = string.Format("http://{your_domain}.wordpress.com/{0}feed/{1}", monthLimit ? monthFilter : "", doPage ? "?paged=" + page : "");
	var items = parser.Parse(url, FeedType.RSS);

	foreach (var item in items)
	{
		var b = new BlogPost()
		{
			Title = item.Title,
			Date = item.PublishDate,
			Content = item.Content,
			Url = item.Link
		};
		posts.Add(b);
	}

	if (posts.Count >= 10)
	{
		ViewBag.HasNext = true;
		ViewBag.NextPage = string.Format("/blog/{0}?page={1}", monthLimit ? monthFilter : "",  page + 1);
	}
	else
	{
		ViewBag.HasNext = false;
	}            

	return View(posts);
}
```
