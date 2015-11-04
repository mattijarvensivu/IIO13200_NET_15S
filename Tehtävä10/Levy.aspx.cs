using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

public partial class Levy : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        /*string category = Request.QueryString["name"];
        XDocument xmlDoc = XDocument.Load("/levyt.xml");

        var Tietoja = from levy in xmlDoc.Descendants("levy")
                           where levy.Element("ISBN").Value == category
                           select new
                           {
                               Name = levy.Element("nimi").Value,
                               hinta = levy.Element("hinta").Value,
                               ISBN = levy.Element("ISBN").Value
                           };

     */

    }


}