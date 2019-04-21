using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.IRepository
{
    public interface IRepository<T> where T : class
    {
        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="model"></param>
        void Create(T model);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="model"></param>
        void Edit(T model);

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);

        /// <summary>
        /// 查询
        /// </summary>
        /// <returns></returns>
        IQueryable<T> Query();

        /// <summary>
        /// Id查询
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Get(int id);

       
    }
}
