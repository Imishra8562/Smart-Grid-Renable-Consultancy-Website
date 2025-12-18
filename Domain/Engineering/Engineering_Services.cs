using System.Collections.Generic;


namespace Domain
{
    [Table("tbl_Engineering_Services")]
    public class Engineering_Services : Base
    {
        public int Engineering_Services_Id { get; set; }
        public string Engineering_Services_Code { get; set; }
        public string Engineering_Services_Name { get; set; }
        public string Engineering_Services_Page_Title { get; set; }
        public string Engineering_Services_Meta_Keyword { get; set; }
        public string Engineering_Services_Meta_Description { get; set; }
        public string Engineering_Services_Image { get; set; }
        public string Engineering_Services_Image_Alt_Tag { get; set; }
        public string Engineering_Services_Description { get; set; }
        public string Engineering_Services_Url_Link { get; set; }

        // Dynamic sections / subtopics
        public IList<Engineering_Services_SubTopic> SubTopics { get; set; }
        public IList<Engineering_Services_Feature> Features { get; set; }
        public IList<Engineering_Services_Application> Applications { get; set; }
        public IList<Engineering_Services_GalleryImage> GalleryImages { get; set; }
        public IList<Engineering_Services_Tab> Tabs { get; set; }

    }

    public class Engineering_Services_SubTopic
    {
        public string Code { get; set; } // e.g., "load-flow"
        public string Name { get; set; } // e.g., "Load Flow Analysis"
        public string Description { get; set; }
    }

    public class Engineering_Services_Feature
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class Engineering_Services_Application
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string IconClass { get; set; } // e.g., "bi bi-building-gear"
    }

    public class Engineering_Services_GalleryImage
    {
        public string ImageUrl { get; set; }
        public string AltText { get; set; }
    }

    public class Engineering_Services_Tab
    {
        public string Id { get; set; } // e.g., "prod-audit"
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
