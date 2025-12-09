using System;
using System.Collections.Generic;

namespace Domain.Admin
{
    public class Knowledge_Base : Base
    {
        [Identifier("Knowledge_Base_Id")]
        public int Knowledge_Base_Id { get; set; }

        // -----------------------
        // BASIC INFO
        // -----------------------
        public string Knowledge_Base_Code { get; set; }
        public string Knowledge_Base_Name { get; set; }
        public string Knowledge_Base_Page_Title { get; set; }

        // -----------------------
        // SEO META
        // -----------------------
        public string Knowledge_Base_Meta_Keyword { get; set; }
        public string Knowledge_Base_Meta_Description { get; set; }
        public string Knowledge_Base_News_Keyword { get; set; }
        public string Knowledge_Base_News_Description { get; set; }

        // -----------------------
        // OPEN GRAPH
        // -----------------------
        public string Knowledge_Base_Og_Image { get; set; }
        public string Knowledge_Base_Og_Title { get; set; }
        public string Knowledge_Base_Og_Description { get; set; }

        // -----------------------
        // MAIN IMAGE
        // -----------------------
        public string Knowledge_Base_Image { get; set; }
        public string Knowledge_Base_Image_Alt_Tag { get; set; }

        // -----------------------
        // OVERVIEW / DESCRIPTION
        // -----------------------
        public string Knowledge_Base_Description { get; set; }

        // -----------------------
        // URL
        // -----------------------
        public string Knowledge_Base_Url_Link { get; set; }

        // =======================
        // PAGE SPECIFIC SECTIONS

        // TECHNICAL SPECIFICATIONS (FEATURE CARDS)
        public List<FeatureCard> Technical_Specifications { get; set; } = new List<FeatureCard>();

        // TESTING & COMMISSIONING WORKFLOW
        public List<WorkflowStep> Testing_Workflow { get; set; } = new List<WorkflowStep>();

        // COMMON FAILURE MODES
        public List<FailureMode> Failure_Modes_List { get; set; } = new List<FailureMode>();

        // RELATED INDUSTRIAL SOLUTIONS
        public List<RelatedSolution> Related_Solutions { get; set; } = new List<RelatedSolution>();
    }

    public class FeatureCard
    {
        public string Icon { get; set; }     // FontAwesome icon name
        public string Title { get; set; }
        public string Description { get; set; }  // can include HTML or simple text
        public List<string> BulletPoints { get; set; } = new List<string>();
    }

    public class WorkflowStep
    {
        public int StepNumber { get; set; }
        public string Stage { get; set; }        // Pre-Comm, Start-Up, Routine, Advanced
        public string Title { get; set; }        // e.g., "Static Testing"
        public List<string> Tasks { get; set; } = new List<string>();
        public string CardColor { get; set; }    // Optional: e.g., "bg-white" or "bg-primary text-white"
    }

    public class FailureMode
    {
        public string Title { get; set; }        // e.g., "Insulation Breakdown"
        public string Description { get; set; }  // e.g., "Aging, moisture, dust..."
    }

    public class RelatedSolution
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string AltTag { get; set; }
        public string UrlLink { get; set; }  // Optional link to the solution page
    }
}
