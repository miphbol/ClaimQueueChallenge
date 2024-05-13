using System.ComponentModel.Design;
using System.Reflection.Metadata;
using System.Runtime.Serialization;
using InsuranceClaims.Repository;

namespace InsuranceClaimsConsole;

public class ProgramUI
{
    private InsranceClaimsRepo _claimRepo = new InsranceClaimsRepo();

    public void Run()
    {
        SeedClaimQueue();
        Menu();
    }

    // Menu

    private void Menu()
    {
        bool keepRunning = true;

        while (keepRunning)
        {
                        System.Console.WriteLine("Select a menu option:\n" +
            "1. Create a claim\n" +
            "2. View the claim queue\n" +
            "3. Preview a claim for processing\n" +
            "4. Exit");


            string input = System.Console.ReadLine();

            switch (input)
            {
                case "1":
                AddClaimToQueue();
                break;

                case "2":
                GetClaimsQueue();
                break;

                case "3":
                ProcessNextClaim();
                break;

                case "4":
                System.Console.WriteLine("Closing claims queue. Good-bye!");
                keepRunning = false;
                break;

                default:
                System.Console.WriteLine("Please enter a valid number.");
                break;
            }

            System.Console.WriteLine("Press any key to continue.");
            System.Console.ReadKey();
            System.Console.Clear();
            

        }
    }

    // Add a claim to the queue

    private void AddClaimToQueue()
    {
        System.Console.Clear();

        InsuranceClaims.Repository.InsuranceClaims newClaim = CreateNewClaimObject();

        // bool wasAdded = _claimRepo.AddClaimToQueue();

        // if (wasAdded)
        // {
        //     System.Console.WriteLine("Claim succesfully added to the queue.");
        // }
        // else
        // {
        //     System.Console.WriteLine("Could not add claim to queue.");
        // }
    }

    private static InsuranceClaims.Repository.InsuranceClaims CreateNewClaimObject()
    {
        InsuranceClaims.Repository.InsuranceClaims newClaim = new InsuranceClaims.Repository.InsuranceClaims();

        System.Console.WriteLine("Enter the ID of the claim:");
        string claimByID = System.Console.ReadLine();
        newClaim.ClaimID = int.Parse(claimByID);

        System.Console.WriteLine("Enter the claim type:");
        newClaim.ClaimType = System.Console.ReadLine();

        System.Console.WriteLine("Enter a description of the claim:");
        newClaim.ClaimDescription = System.Console.ReadLine();
        
        System.Console.WriteLine("Enter the dollar amount of damage:");
        string claimDollar = System.Console.ReadLine();
        newClaim.ClaimAmount = double.Parse(claimDollar);

        System.Console.WriteLine("Enter the date of the accident (yyyy, mm, dd):");
        string accidentDate = System.Console.ReadLine();
        newClaim.DateOfIncident = DateTime.Parse(accidentDate);

        System.Console.WriteLine("Enter the date of the claim was submitted (yyyy, mm, dd):");
        string claimDate = System.Console.ReadLine();
        newClaim.DateOfClaim = DateTime.Parse(claimDate);

        System.Console.WriteLine("Is the claim date greater than 30 days of the accident date?");
        string validDateString = System.Console.ReadLine().ToLower();

        if (validDateString == "y")
        {
            newClaim.IsValid = true;
        }
        else
        {
            newClaim.IsValid = false;
        }
        

        return newClaim;
        
    }

    // View the queue of current claims

    private void GetClaimsQueue()
    {
        System.Console.Clear();

        Queue<InsuranceClaims.Repository.InsuranceClaims> queueOfClaims = _claimRepo.GetClaimsQueue();
        

        foreach (InsuranceClaims.Repository.InsuranceClaims claim in queueOfClaims)
        {
            System.Console.WriteLine(
                $"Claim ID: {claim.ClaimID}\n" +
                $"Claim Type: {claim.ClaimType}\n" +
                $"Claim Description: {claim.ClaimDescription}\n" +
                $"Amount of Damage: {claim.ClaimAmount}\n" +
                $"Date of Accident: {claim.DateOfIncident}\n" +
                $"Date of Claim: {claim.DateOfClaim}\n" +
                $"Is the claim valid? {claim.IsValid} "
                
            );
        }
    }

    // Preview a claim then process

    private void ProcessNextClaim()
    
{
    System.Console.Clear();

    GetClaimsQueue();

    System.Console.WriteLine($"Would you like to preview the next claim in the queue? (Y/N)");

    string previewInput = System.Console.ReadLine().ToLower();

    if (previewInput == "y")
    {
        _claimRepo.PreviewNextClaim();

        System.Console.WriteLine($"Would you like to process this claim? (Y/N)");

        string dequeueInput = System.Console.ReadLine().ToLower();

        if (dequeueInput == "y")
        {
            _claimRepo.RemoveClaim();
            System.Console.WriteLine("Claim has been processed.");
        }
        else
        {
            return;
        }
    }
    else
    {
        return;
    }
}

// Seed queue

private void SeedClaimQueue()
{
    InsuranceClaims.Repository.InsuranceClaims autoaccident = new InsuranceClaims.Repository.InsuranceClaims(1, "Auto Accident", "Fender bender involving customer's vehicle", 3207.88, new DateTime(2024, 5, 7), new DateTime(2024, 5, 12), true);
    InsuranceClaims.Repository.InsuranceClaims boataccident = new InsuranceClaims.Repository.InsuranceClaims(2, "Boat Accident", "Boat was eaten by large shark", 20035.55, new DateTime(2024, 5, 1), new DateTime(2024, 6, 2), false);

    _claimRepo.AddClaimToQueue(autoaccident);
    _claimRepo.AddClaimToQueue(boataccident);


}






    }












