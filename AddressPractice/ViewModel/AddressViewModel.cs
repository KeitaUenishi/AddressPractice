using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AddressPractice.Models;

namespace AddressPractice.ViewModel
{
    public class AddressViewModel
    {
        /// <summary>
        /// 検索条件格納
        /// </summary>
        public ADDRESS_MASTER SearchCondition { get; set; } = new ADDRESS_MASTER();
        /// <summary>
        /// データ格納
        /// </summary>
        public IEnumerable<ADDRESS_MASTER> AddresMasters { get; set; }
        /// <summary>
        /// 新規登録時に割り振るID（最大値 + 1）
        /// </summary>
        public int NewCreateIdData { get; set; } = new int();


        private EfPracticeEntities DbCxt;

        public AddressViewModel(EfPracticeEntities dbCxt)
        {
            DbCxt = dbCxt;
        }
        public AddressViewModel Initialize(ADDRESS_MASTER address)
        {
            SearchCondition = address;
            return this;
        }

        public AddressViewModel Initialize()
        {
            
            var maxIdNum = DbCxt.ADDRESS_MASTER.Max(x => x.id);
            maxIdNum++;
            NewCreateIdData = (int)maxIdNum;
            return this;
        }

        public AddressViewModel LordRecordObjects()
        {
            AddresMasters = DbCxt.ADDRESS_MASTER
                .WhereIf(SearchCondition.id != null, x => x.id == SearchCondition.id)
                .WhereIf(SearchCondition.name != null, x => x.name == SearchCondition.name)
                .WhereIf(SearchCondition.fromBirthDay != null, x => x.birthDay >= SearchCondition.fromBirthDay)
                .WhereIf(SearchCondition.toBirthDay != null, x => x.birthDay <= SearchCondition.toBirthDay)
                .Select(x => x)
                .OrderBy(x => x.id).ToList();

            return this;
        }
    }
}