using System;

namespace CSharpCode
{
    /*------------------------------------------------------------------------------------------------------------------
    Delegate is used as a pipeline to pass data.
    Event Raiser (Event) ----- Delegates -----> Event Listener (Event Handler).
    Delegate is a function pointer.
    Allows our event and the EventArgs to get over to the event handler.
    Delegates inherits form MulticastDelegate base class, MulticastDelegate inherits from Delegate base.
    You cant inherit from MulticastDelegate or Delegate class , the delegate keyword does the magic with compiler
    The abstract class Delegate has 2 important properties Method - Gets the method represented by the delegate
    and Target - Gets the class instance on which the current delegate invokes the instance method and a method
    called GetInvocationList() - Returns the invocation list of the delegate.
    Invocation list is the list of objects listening from an event
    ------------------------------------------------------------------------------------------------------------------*/
    
    
    //
    // Create delegate blueprint or stub. 
    // Returning void means this delegate is one way forward, nothing comes back.
    public delegate void SimpleDelegateHandler (int intData, CustomData cusIntData );
    
    //
    // Create a delegate that return something.
    public delegate int SimpleDelegateReturnHandler (int intData, CustomData cusIntData );
    
    
    /// <summary>
    ///     Delegates example code
    /// </summary>
    /// 
    public static class DelegateExamples
    {
        #region Simple Delegate ----------------------------------------------------------------------------------------

        //
        // Methods that match Delegate handler signature, they must match
        public static void SimpleDelegateMethodA(int dataInt, CustomData dataCus)
        {
            Console.Write( "Running delegate A : {0} : {1} {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);
        }

        public static void SimpleDelegateMethodB(int dataInt, CustomData dataCus)
        {
            Console.Write( "Running delegate B : {0} : {1}  {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);
        }

        #endregion

        
        #region Simple Delegate With Dynamic Method --------------------------------------------------------------------

        //
        // Dynamic method , is know noting of the method its executing
        public static void DynamicMethodA(SimpleDelegateHandler delegateHandler)
        {
            delegateHandler( 20, new CustomData {CustomDataInt = "DynamicMethodA"});
        }

        public static void DynamicMethodB(SimpleDelegateHandler delegateHandler)
        {
            delegateHandler( 40, new CustomData {CustomDataInt = "DynamicMethodB"});
        }
        
        #endregion
        
        
        #region Simple Multi Delegate With Dynamic Method --------------------------------------------------------------
        
        public static void SimpleDelegateMethodC(int dataInt, CustomData dataCus)
        {
            Console.Write( "Running delegate C : {0} : {1}  {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);
        }
        
        #endregion
        
        
        #region Simple Delegate With Return ----------------------------------------------------------------------------

        //
        // Methods that match Delegate handler signature, they must match
        public static int SimpleDelegateReturnMethodA(int dataInt, CustomData dataCus)
        {
            Console.Write( "Running delegate A : {0} : {1} {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);

            return dataInt;
        }

        public static int SimpleDelegateReturnMethodB(int dataInt, CustomData dataCus)
        {
            Console.Write( "Running delegate B : {0} : {1}  {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);

            return dataInt;
        }

        #endregion

        
        #region Simple Multi Delegate With Returns ---------------------------------------------------------------------

        public static int SimpleDelegateReturnMethodC(int dataInt, CustomData dataCus)
        {
            Console.Write( "Running multi delegate C : {0} : {1}  {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);

            return dataInt;
        }
        #endregion
    }
}
