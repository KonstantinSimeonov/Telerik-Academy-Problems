using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace StudentRegistration
{
    public partial class StudentRegistrationForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IQueryable<string> GetUniversities()
        {
            return new[] { "СУ", "ТУ", "УНСС", "Юзото" }.AsQueryable();
        }

        public IQueryable<string> GetSpecialties()
        {
            return new[] { "Computer Science", "Law", "Finances", "Choplene na semki", "Operation of biological units" }.AsQueryable();
        }

        public IQueryable<string> GetCourses()
        {
            return new[] { "NodeJS for beginners", "Law101", "Global finance flows", "Doene na kozi101" }.AsQueryable();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var lblName = "<h3>Name: </h3>";
            var fullName = "<p>" + this.tbFirstName.Text + " " + this.tbLastName.Text + "</p>";
            var universityInfo = "<p>Faculty number: " + this.tbFacultyNumber.Text + " in " + this.ddlUniversities.SelectedValue + "</p>";
            var courses = "<h4>Currently attending the courses: </h4><ul>";

            foreach (ListItem item in this.cblCourses.Items)
            {
                if(item.Selected)
                {
                    courses += "<li>" + item.Text + "</li>";
                }
            }

            courses += "</ul>";

            this.ltlResult.Text = lblName + fullName + universityInfo + courses;
        }
    }
}