namespace InsuranceClaims.Repository;

public class InsranceClaimsRepo
{
    private Queue<InsuranceClaims> _insuranceClaimsQueue = new Queue<InsuranceClaims>();

    // Create

    public void AddClaimToQueue (InsuranceClaims claim)
    {
        _insuranceClaimsQueue.Enqueue(claim);
    }

    // Read

    public Queue<InsuranceClaims> GetClaimsQueue()
    {
        return new Queue<InsuranceClaims>(_insuranceClaimsQueue);
    }


    // Delete

    public bool RemoveClaim ()
    {
        _insuranceClaimsQueue.Dequeue();

        return true;
    }


    public InsuranceClaims PreviewNextClaim()
    {
        return _insuranceClaimsQueue.Peek();
    }

    public void PreviewAndDequeue()
    {
        Queue<InsuranceClaims> queue = new Queue<InsuranceClaims>();

        
    }



}

