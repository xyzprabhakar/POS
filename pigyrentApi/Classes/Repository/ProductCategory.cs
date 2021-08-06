using pigyrentApi.Classes.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pigyrentApi.Classes.Repository
{


    public class ProductCategory
    {
        private readonly PgContext _PgContext;
        public ProductCategory(PgContext pgContext)
        {
            _PgContext = pgContext;
        }
        public IEnumerable<tbl_Product_Category> GetAll(bool OnlyActive=false)
        {
            if (OnlyActive)
            {
                return _PgContext.tbl_Product_Category.Where(p => p.IsActive).ToList();
            }
            else
            {
                return _PgContext.tbl_Product_Category.ToList();
            }
        }

        public tbl_Product_Category GetById(int CategoryId)
        {
            return _PgContext.tbl_Product_Category.Find(CategoryId);
        }

        public IEnumerable<tbl_Product_Category> GetAllParent(int CategoryId)
        {
            return _PgContext.tbl_Product_Category_Tree.Where(p => p.CategoryId == CategoryId && p.IsActive)
                .OrderBy(p=>p.DepthId)
                .Join(_PgContext.tbl_Product_Category,
                tree => tree.ParentCategoryId,
                caterory => caterory.CategoryId,
                (tree, caterory)=> caterory
                ).ToList();
        }
        public IEnumerable<tbl_Product_Category> GetAllChild(int CategoryId)
        {
            return _PgContext.tbl_Product_Category_Tree.Where(p => p.ParentCategoryId == CategoryId && p.IsActive)
                .OrderBy(p => p.DepthId)
                .Join(_PgContext.tbl_Product_Category,
                tree => tree.CategoryId,
                caterory => caterory.CategoryId,
                (tree, caterory) => caterory
                ).ToList();
        }

        public IEnumerable<tbl_Product_Category> GetImmediateChild(int CategoryId)
        {
            return _PgContext.tbl_Product_Category.Where(p => p.CategoryId== CategoryId )
                .Join(_PgContext.tbl_Product_Category,
                parent => parent.CategoryId,
                child => child.ParentCategoryId,
                (parent, child) => child
                ).OrderBy(p=>p.CategoryId).ToList();
        }


    }
}
