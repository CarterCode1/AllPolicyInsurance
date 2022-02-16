namespace AllPolicyInsurance.Dto
{
    public class CreatePolicyResponse
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public PolicyDTO Policy { get; set; }
    }
}
