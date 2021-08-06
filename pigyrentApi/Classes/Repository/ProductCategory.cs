using Microsoft.EntityFrameworkCore;
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
        private bool disposed = false;
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
        
        public void Insert(tbl_Product_Category mdl)
        {
            if (mdl.ParentCategoryId == 0)
            {
                mdl.ParentCategoryId = null;
            }
            else if (mdl.ParentCategoryId > 0)
            {
                var Parentdata=GetById(mdl.ParentCategoryId.Value);
                if (Parentdata != null)
                { 
                    
                }
            }
            _PgContext.tbl_Product_Category.Add(mdl);
            
        }
        public void Update(tbl_Product_Category mdl)
        {
            _PgContext.Entry(mdl).State = EntityState.Modified;
        }
        public void Delete(int CategoryId)
        {
            var mdl = GetById(CategoryId);
            _PgContext.tbl_Product_Category.Remove(mdl);
        }
        public void Save()
        {
            _PgContext.SaveChanges();
        }
        
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _PgContext.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}
