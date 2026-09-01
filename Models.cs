namespace Summary.Liyam
{
    using System;
    using System.Collections.Generic;

    public class ProductSubmitModel
    {
        public string EntityName { get; set; }
        public string ActionType { get; set; }
        public GoodsInfo Entity { get; set; }
    }

    public class GoodsInfo
    {
        public string CostOrIncomeStr { get; set; }
        public string GoodsTypeStr { get; set; }
        public string GoodsSubTypeStr { get; set; }
        public string LockedStr { get; set; }
        public string HasVatStr { get; set; }
        public string Message { get; set; }
        public int MessageType { get; set; }
        public int GoodsGroup_GoodsGroupId { get; set; }
        public string GoodsGroup_Title { get; set; }
        public int GoodsGroup_Code { get; set; }
        public string GoodsGroup_Lookup { get; set; }
        public string GoodsSubGroup_Title { get; set; }
        public int GoodsSubGroup_Code { get; set; }
        public string GoodsSubGroup_Lookup { get; set; }
        public string FullTitle { get; set; }
        public string FullCode { get; set; }
        public string Unit_Title { get; set; }
        public string BaseUnit_Title { get; set; }
        public string Unit_Lookup { get; set; }
        public string BaseUnit_Lookup { get; set; }
        public int Ratio { get; set; }
        public string JsonData { get; set; }
        public decimal? GoodsAmount { get; set; }
        public decimal LastBuyPrice { get; set; }
        public decimal LastSalePrice { get; set; }
        public decimal? Amount { get; set; }
        public int? WarehouseId { get; set; }
        public string Warehouse_Title { get; set; }
        public string ServiceDetail_Lookup { get; set; }
        public string ServiceLedger_Lookup { get; set; }
        public string ServiceLevel5_Lookup { get; set; }
        public string ServiceDetail_Title { get; set; }
        public string ServiceLedger_Title { get; set; }
        public string ServiceLevel5_Title { get; set; }
        public string ServiceDetail_FullCode { get; set; }
        public string ServiceLedger_FullCode { get; set; }
        public string ServiceLevel5_FullCode { get; set; }
        public string AttributesStr { get; set; }
        public string RelatedGoods_Lookup { get; set; }
        public string ServiceGroup_Lookup { get; set; }
        public int GoodsId { get; set; }
        public object GoodsGroup { get; set; }
        public int GoodsSubGroupId { get; set; }
        public object GoodsSubGroup { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Model { get; set; }
        public int UnitId { get; set; }
        public object Unit { get; set; }
        public bool IsDualUnit { get; set; }
        public int BaseUnitId { get; set; }
        public int GoodsType { get; set; }
        public int CostOrIncome { get; set; }
        public string TechnicalCode { get; set; }
        public string Barcode { get; set; }
        public string ExternalCode { get; set; }
        public bool HasVAT { get; set; }
        public decimal? VatPercent { get; set; }
        public bool Locked { get; set; }
        public int? OrderPoint { get; set; }
        public int? StagnantLimit { get; set; }
        public int? ServiceDetailId { get; set; }
        public int? ServiceLedgerId { get; set; }
        public int ServiceLevel5Id { get; set; }
        public string StuffId { get; set; }
        public string CurrencyISOCode { get; set; }
        public bool ShowInQuickInvoice { get; set; }
        public bool HasGuaranty { get; set; }
        public int GoodsSubType { get; set; }
        public string RelatedGoods { get; set; }
        public int? ServiceGroupId { get; set; }
        public string AttributeSignature { get; set; }
        public List<object> Attributes { get; set; } = new List<object>();
        public DateTime CreatedDate { get; set; }
        public int? CreatedUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserID { get; set; }
    }

    public class IdentitySubmitModel
    {
        public string EntityName { get; set; }
        public string ActionType { get; set; }
        public DetailEntity Entity { get; set; }
    }

    public class DetailEntity
    {
        public string Person_PersonTypeStr { get; set; }
        public string Person_TaxStatusStr { get; set; }
        public string LockedStr { get; set; }
        public string IsSecretStr { get; set; }
        public string Message { get; set; }
        public int MessageType { get; set; }
        public string FullCode { get; set; }
        public string FullTitle { get; set; }
        public double? DebtDiff { get; set; }
        public double? CreditDiff { get; set; }
        public double Diff { get; set; }
        public string Cheque_Bank_Title { get; set; }
        public string Cheque_Bank_FullCode { get; set; }
        public string Cheque_Bank_Lookup { get; set; }
        public int? StateId { get; set; }
        public string State_Title { get; set; }
        public string State_Lookup { get; set; }
        public string City_Title { get; set; }
        public string City_Lookup { get; set; }
        public string ReferenceKey { get; set; }
        public int UseCode { get; set; }
        public string UseCodeStr { get; set; }
        public string DetailGroupTitle { get; set; }
        public int Level { get; set; }
        public string Level5_Lookup { get; set; }
        public string Level5_Title { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int CreatedUserID { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public int? ModifiedUserID { get; set; }
        public int? Level5Id { get; set; }
        public int DetailId { get; set; }
        public int DetailCode { get; set; }
        public string Title { get; set; }
        public string Cheque_Bank { get; set; }
        public int? Cheque_BankId { get; set; }
        public int Person_PersonType { get; set; }
        public string Person_Name { get; set; }
        public string Person_FirstName { get; set; }
        public string Person_LastName { get; set; }
        public string Person_Brand { get; set; }
        public string Person_NationalCode { get; set; }
        public string Person_EconomicCode { get; set; }
        public string Person_BranchCode { get; set; }
        public int? Person_RegisterNo { get; set; }
        public string Person_Address { get; set; }
        public string Person_Phone { get; set; }
        public string Person_Fax { get; set; }
        public string Person_Mobile { get; set; }
        public string Person_Email { get; set; }
        public string Person_PostalCode { get; set; }
        public string Person_AccountNumber { get; set; }
        public string Person_CardNumber { get; set; }
        public string Person_ShebaNumber { get; set; }
        public string Person_Ceo { get; set; }
        public string Person_FinantionalManager { get; set; }
        public double? Person_ChequeCredit { get; set; }
        public double? Person_AccountCredit { get; set; }
        public string Description { get; set; }
        public bool Locked { get; set; }
        public string InActivityReason { get; set; }
        public bool IsSecret { get; set; }
        public object City { get; set; }
        public int? CityId { get; set; }
        public int? Person_TaxStatus { get; set; }
        public object DetailGroup { get; set; }
        public int DetailGroupId { get; set; }
        public int? OrgUnitId { get; set; }
        public object OrgUnit { get; set; }
        public bool LimitedAccess { get; set; }
        public object CostMode { get; set; }
    }

    public class DetailGroupLookupItem
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

    public class LookupItem
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }

    public class ResponseTokenInfo
    {
        public string Access_Token { get; set; }
    }

}