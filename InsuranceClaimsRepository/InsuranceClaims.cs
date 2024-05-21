namespace InsuranceClaims.Repository;

public class InsuranceClaims
{
    public int ClaimID { get; set; }
    public string ClaimType { get; set; }
    public string ClaimDescription { get; set; }
    public double ClaimAmount { get; set; }
    public DateTime DateOfIncident { get; set; }
    public DateTime DateOfClaim { get; set; }
    public bool IsValid { get; set; }

    public InsuranceClaims() {}

    public InsuranceClaims(int claimid, string claimtype, string claimdescription, double claimamount, DateTime dateofincident, DateTime dateofclaim, bool isvalid)
    {
        ClaimID = claimid;
        ClaimType = claimtype;
        ClaimDescription = claimdescription;
        ClaimAmount = claimamount;
        DateOfIncident = dateofincident;
        DateOfClaim = dateofclaim;
        IsValid = isvalid;
    }
}
