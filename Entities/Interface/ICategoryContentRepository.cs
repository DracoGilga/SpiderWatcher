﻿using Entities.Poco;

namespace Entities.Interface
{
    public interface ICategoryContentRepository
    {
        void CreateCategoryContent(CategoryContent categoryContent);
        CategoryContent ReadCategoryContent(int id);
        bool UpdateCategoryContent(CategoryContent categoryContent);
        CategoryContent DeleteCategoryContent(int id);

        IEnumerable<CategoryContent> ReadAllCategoryContents();
    }
}
