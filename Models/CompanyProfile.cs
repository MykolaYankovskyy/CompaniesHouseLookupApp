using Newtonsoft.Json;

namespace CompaniesHouseLookupApp.Models
{
    public class CompanyProfile
    {
        [JsonProperty("accounts")]
        public Accounts? Accounts { get; set; }

        [JsonProperty("annual_return")]
        public AnnualReturn? AnnualReturn { get; set; }

        [JsonProperty("branch_company_details")]
        public BranchCompanyDetails? BranchCompanyDetails { get; set; }

        [JsonProperty("can_file")]
        public bool CanFile { get; set; }

        [JsonProperty("company_name")]
        public required string CompanyName { get; set; }

        [JsonProperty("company_number")]
        public required string CompanyNumber { get; set; }

        [JsonProperty("company_status")]
        public required string CompanyStatus { get; set;}

        [JsonProperty("company_status_detail")]
        public string? CompanyStatusDetail { get; set; }

        [JsonProperty("confirmation_statement")]
        public ConfirmationStatement? ConfirmationStatement { get; set; }

        [JsonProperty("date_of_creation")]
        public required string DateOfCreation { get; set; }

        [JsonProperty("date_of_cessation")]
        public string? DateOfCessation { get; set; }

        [JsonProperty("etag")]
        public string? Etag { get; set; }

        [JsonProperty("foreign_company_details")]
        public ForeignCompanyDetails? ForeignCompanyDetails { get; set; }

        [JsonProperty("has_been_liquidated")]
        public bool? HasBeenLiquidated { get; set; }

        [JsonProperty("has_charges")]
        public bool? HasCharges { get; set; }

        [JsonProperty("has_insolvency_history")]
        public bool? HasInsolvencyHistory { get; set; }

        [JsonProperty("is_community_interest_company")]
        public bool? IsCommunityInterestCompany { get; set; }

        [JsonProperty("jurisdiction")]
        public required string Jurisdiction { get; set; }

        [JsonProperty("last_full_members_list_date")]
        public string? LastFullMembersListDate { get; set; }

        [JsonProperty("links")]
        public Links? Links { get; set; }

        [JsonProperty("previous_company_names")]
        public List<PreviousCompanyName>? PreviousCompanyNames { get; set; }

        [JsonProperty("registered_office_address")]
        public RegisteredOfficeAddress? RegisteredOfficeAddress { get; set; }

        [JsonProperty("registered_office_is_in_dispute")]
        public bool? RegisteredOfficeIsInDispute { get; set; }

        [JsonProperty("service_address")]
        public Address? ServiceAddress { get; set; }

        [JsonProperty("sic_codes")]
        public List<string>? SicCodes { get; set; }

        [JsonProperty("super_secure_managing_officer_account")]
        public int? SuperSecureManagingOfficerAccount { get; set; }

        [JsonProperty("type")]
        public required string Type { get; set; }

        [JsonProperty("undeliverable_registered_office_address")]
        public bool? UndeliverableRegisteredOfficeAddress { get; set; }
    }

    public class Address
    {
        [JsonProperty("address_line_1")]
        public string? AddressLine1 { get; set; }

        [JsonProperty("address_line_2")]
        public string? AddressLine2 { get; set; }

        [JsonProperty("care_of")]
        public string? CareOf { get; set; }

        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("locality")]
        public string? Locality { get; set; }

        [JsonProperty("po_box")]
        public string? PoBox { get; set; }

        [JsonProperty("postal_code")]
        public string? PostalCode { get; set; }

        [JsonProperty("region")]
        public string? Region { get; set; }
    }

    public class RegisteredOfficeAddress : Address
    {
        [JsonProperty("premises")]
        public string? Premises { get; set; }
    }

    public class PreviousCompanyName
    {
        [JsonProperty("ceased_on")]
        public required string CeasedOn { get; set; }

        [JsonProperty("effective_from")]
        public required string EffectiveFrom { get; set; }

        [JsonProperty("name")]
        public required string Name { get; set; }
    }

    public class Links
    {
        [JsonProperty("persons_with_significant_control")]
        public string? PersonsWithSignificantControl { get; set; }

        [JsonProperty("persons_with_significant_control_statements")]
        public string? PersonsWithSignificantControlStatements { get; set; }

        [JsonProperty("registers")]
        public string? Registers { get; set; }

        [JsonProperty("self")]
        public required string Self { get; set; }
    }

    public class ForeignCompanyDetails
    {
        [JsonProperty("accounts")]
        public ForeignAccounts? Accounts { get; set; }

        [JsonProperty("business_activity")]
        public string? BusinessActivity { get; set; }

        [JsonProperty("company_type")]
        public string? CompanyType { get; set; }

        [JsonProperty("governed_by")]
        public string? GovernedBy { get; set; }

        [JsonProperty("is_a_credit_finance_institution")]
        public bool? IsACreditFinanceInstitution { get; set; }

        [JsonProperty("originating_registry")]
        public OriginatingRegistry? OriginatingRegistry { get; set; }

        [JsonProperty("registration_number")]
        public string? RegistrationNumber { get; set; }
    }

    public class ForeignAccounts
    {
        [JsonProperty("account_period_from")]
        public DateObject? AccountPeriodFrom { get; set; }

        [JsonProperty("account_period_to")]
        public DateObject? AccountPeriodTo { get; set; }

        [JsonProperty("must_file_within")]
        public MustFileWithinObject? MustFileWithin { get; set; }
    }

    public class MustFileWithinObject
    {
        [JsonProperty("months")]
        public int? Months { get; set; }
    }

    public class OriginatingRegistry
    {
        [JsonProperty("country")]
        public string? Country { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

    public class ConfirmationStatement
    {
        [JsonProperty("last_made_up_to")]
        public string? LastMadeUpTo { get; set; }

        [JsonProperty("next_due")]
        public required string NextDue { get; set; }

        [JsonProperty("next_made_up_to")]
        public required string NextMadeUpTo { get; set; }

        [JsonProperty("overdue")]
        public bool? Overdue { get; set; }
    }

    public class BranchCompanyDetails
    {
        [JsonProperty("business_activity")]
        public string? BusinessActivity { get; set; }

        [JsonProperty("parent_company_name")]
        public string? ParentCompanyName { get; set; }

        [JsonProperty("parent_company_number")]
        public string? ParentCompanyNumber { get; set; }
    }

    public class AnnualReturn
    {
        [JsonProperty("last_made_up_to")]
        public string? LastMadeUpTo { get; set; }

        [JsonProperty("next_due")]
        public string? NextDue { get; set; }

        [JsonProperty("next_made_up_to")]
        public string? NextMadeUpTo { get; set; }

        [JsonProperty("overdue")]
        public bool? Overdue { get; set; }
    }

    public class Accounts
    {
        [JsonProperty("accounting_reference_date")]
        public DateObject? AccountingReferenceDate { get; set; }

        [JsonProperty("last_accounts")]
        public LastAccounts? LastAccounts { get; set; }

        [JsonProperty("next_due")]
        public string? NextDue { get; set; }

        [JsonProperty("next_made_up_to")]
        public required string NextMadeUpTo { get; set; }

        [JsonProperty("overdue")]
        public bool? Overdue { get; set; }
    }

    public class LastAccounts
    {
        [JsonProperty("made_up_to")]
        public required string MadeUpTo { get; set; }

        [JsonProperty("type")]
        public required string Type { get; set; }
    }

    public class DateObject
    {
        [JsonProperty("day")]
        public int? Day { get; set; }

        [JsonProperty("month")]
        public int? Month { get; set; }
    }
}
