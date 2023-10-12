namespace LibraryManagementApp.Core
{
    public class Loan
    {
        public User User;
        public Document LoanedDocument;
        public string? LoanId;
        public DateTime StartTime;
        public DateTime EndTime;

        public Loan(User user, Book loanedBook, string? loanId, DateTime startTime, DateTime endTime)
        {
            User = user;
            LoanedDocument = loanedBook;
            LoanId = loanId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public Loan(User user, DVD borrowedDvd, string? loanId, DateTime startTime, DateTime endTime)
        {
            User = user;
            LoanedDocument = borrowedDvd;
            LoanId = loanId;
            StartTime = startTime;
            EndTime = endTime;
        }

        public override string ToString()
        {
            string itemType = LoanedDocument is Book ? "Book" : "DVD";
            return $"{User.Name}, {User.Lastname} loaned {itemType} : {LoanedDocument.Title} ({LoanedDocument.GetType().Name} from {StartTime} to {EndTime}.)";
        }
    }

}