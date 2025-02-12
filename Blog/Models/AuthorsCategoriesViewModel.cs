using System.Collections.Generic;
using Blog.Models;

namespace Blog.ViewModels {
    public class AuthorsCategoriesViewModel {
        public List<Author> Authors { get; set; }
        public List<Category> Categories { get; set; }
    }
}
