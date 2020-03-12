
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using FSISSystem.BLL;
using FSISSystem.ENTITIES;


namespace WebAppFSIS.ExercisePages

{
    public partial class SimpleQuery : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            MessageLabel.Text = "";
        }

        protected void Fetch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(RegionIDArg.Text))
            {
                MessageLabel.Text = "Enter a Team id value.";
            }
            else
            {
                int regionid = 0;
                if (int.TryParse(RegionIDArg.Text, out regionid))
                {
                    if (regionid > 0)
                    {
                        TeamController sysmgr = new TeamController();
                        Team info = null;
                        info = sysmgr.Teams_FindByID(regionid); //BLL controller method
                        if (info == null)
                        {
                            MessageLabel.Text = "Team ID not found.";
                            RegionID.Text = "";
                            RegionDescription.Text = "";
                        }
                        else
                        {
                            RegionID.Text = info.TeamID.ToString();
                            RegionDescription.Text = info.TeamName;
                        }
                    }
                    else
                    {
                        MessageLabel.Text = "Team id must be greater than 0";
                    }

                }
                else
                {
                    MessageLabel.Text = "Team id must be a number.";
                }
            }
        }
    }
}