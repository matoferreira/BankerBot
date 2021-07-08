using System;

namespace Library
{
    public class HandlersList
    {
            public AddExpenseHandler addExpenseHandler { get; private set; }
            public AddIncomeHandler addIncomeHandler{ get; private set; }
            public AddInternalTransferHandler addInternalTransferHandler{ get; private set; }
            public AddMovementHandler addMovementHandler{ get; private set; }
            public CommandsHandler commandsHandler{ get; private set; }
            public ExpenseAnalysisHandler expenseAnalysisHandler{ get; private set; }
            public NewBankAccountHandler newBankAccountHandler{ get; private set; }
            public NewCreditCardHandler newCreditCardHandler{ get; private set; }
            public NewPaymentMethodHandler newPaymentMethodHandler{ get; private set; }
            public NewWalletHandler newWalletHandler{ get; private set; }
            public SavingsAnalysisHandler savingsAnalysisHandler{ get; private set; }
            public StatusHandler statusHandler{ get; private set; }
            public UpdateAlertHandler updateAlertHandler{ get; private set; }
            public UpdateHighSpendingAlertHandler updateHighSpendingAlertHandler{ get; private set; }
            public UpdateLowFundsAlertHandler updateLowFundsAlertHandler{ get; private set; }
            public UpdateSavingsAlertHandler updateSavingsAlertHandler{ get; private set; }
            public NoComprendoHandler noComprendoHandler {get; private set; }
            public StartHandler startHandler {get; private set; }
        public HandlersList()
        {
            this.addExpenseHandler = new AddExpenseHandler();
            this.addIncomeHandler = new AddIncomeHandler();
            this.addInternalTransferHandler = new AddInternalTransferHandler();
            this.addMovementHandler = new AddMovementHandler();
            this.commandsHandler = new CommandsHandler();
            this.expenseAnalysisHandler = new ExpenseAnalysisHandler();
            this.newBankAccountHandler = new NewBankAccountHandler();
            this.newCreditCardHandler = new NewCreditCardHandler();
            this.newPaymentMethodHandler = new NewPaymentMethodHandler();
            this.newWalletHandler = new NewWalletHandler();
            this.savingsAnalysisHandler = new SavingsAnalysisHandler();
            this.statusHandler = new StatusHandler();
            this.updateAlertHandler = new UpdateAlertHandler();
            this.updateHighSpendingAlertHandler = new UpdateHighSpendingAlertHandler();
            this.updateLowFundsAlertHandler = new UpdateLowFundsAlertHandler();
            this.updateSavingsAlertHandler = new UpdateSavingsAlertHandler();
            this.noComprendoHandler = new NoComprendoHandler();
            this.startHandler = new StartHandler();

            startHandler.Next = commandsHandler;
            commandsHandler.Next = statusHandler;
            statusHandler.Next = newPaymentMethodHandler;
            newPaymentMethodHandler.Next = newBankAccountHandler;
            newBankAccountHandler.Next = newCreditCardHandler;
            newCreditCardHandler.Next = newWalletHandler;
            newWalletHandler.Next = updateAlertHandler;
            updateAlertHandler.Next = updateSavingsAlertHandler;
            updateSavingsAlertHandler.Next = updateLowFundsAlertHandler;
            updateLowFundsAlertHandler.Next = updateHighSpendingAlertHandler;
            updateHighSpendingAlertHandler.Next = statusHandler;
            savingsAnalysisHandler.Next = expenseAnalysisHandler;
            expenseAnalysisHandler.Next = addMovementHandler;
            addMovementHandler.Next = addIncomeHandler;
            addIncomeHandler.Next = addExpenseHandler;
            addExpenseHandler.Next = addInternalTransferHandler;
            addInternalTransferHandler.Next = noComprendoHandler;
            noComprendoHandler.Next = null;
        }
    }
}



