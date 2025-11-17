namespace Biblioteca.DTO
{
    public class LoansDTO
    {
        public int Id { get; set; }                        
        public int BookId { get; set; }                    
        public int MemberId { get; set; }                  
        public DateTime LoanDate { get; set; }             
        public DateTime ExpectedReturnDate { get; set; }   
        public DateTime? ReturnDate { get; set; }          
        public bool StatusReturned { get; set; }
    }
}
