using System;
using System.Xml;

namespace CSharpCode
{
    public class Program
    {
        private static void Main(string[] args)
        {
            #region Simple Delegate ------------------------------------------------------------------------------------
           
            //
            // Setup delegates 
            SimpleDelegateHandler delegateA = DelegateExamples.SimpleDelegateMethodA;
            SimpleDelegateHandler delegateB = new SimpleDelegateHandler(DelegateExamples.SimpleDelegateMethodB);
           
            //
            // Invoke delegate
            delegateA(2, new CustomData {CustomDataInt = "delegateA"});
            delegateB(4, new CustomData {CustomDataInt = "delegateB"});
           
            #endregion
           
           
            #region Simple Delegate With Dynamic Method ----------------------------------------------------------------
           
            //
            // Invoke delegate from dynamic methods
            DelegateExamples.DynamicMethodA(delegateA);
            DelegateExamples.DynamicMethodB(delegateB);
           
            #endregion
            
            
            #region Simple Multi Delegate With Dynamic Method ----------------------------------------------------------
            
            //
            //  Setup delegate
            SimpleDelegateHandler delegateC = new SimpleDelegateHandler(DelegateExamples.SimpleDelegateMethodC);
            delegateC(6, new CustomData {CustomDataInt = "multiDelegateC"});
            
            //
            // Chain delegate in GetInvocationList
            delegateA += delegateB;
            delegateC += delegateA;
            
            //
            // Invoke delegate
            delegateC( 8, new CustomData(){CustomDataInt = "Chain delegate"});
            
            //
            // Loop ove InvocationList ( list of methods we are pointing too)
            foreach (Delegate del in delegateC.GetInvocationList())
            {
                var delInfo = del;
                Console.Write("Looping over invocation list {0} {1}", delInfo.Method.Name,  Environment.NewLine);
            }
           
            #endregion
            
            
            #region Simple Delegate With Return ------------------------------------------------------------------------
           
            //
            // Setup delegates 
            SimpleDelegateReturnHandler delegateReturnHandlerA = new SimpleDelegateReturnHandler(DelegateExamples.SimpleDelegateReturnMethodA);
            SimpleDelegateReturnHandler delegateReturnHandlerB = new SimpleDelegateReturnHandler(DelegateExamples.SimpleDelegateReturnMethodB);
            
            //
            // Invoke delegate
            int returnA = delegateReturnHandlerA(10, new CustomData() {CustomDataInt = "delegateReturnHandlerA"});
            int returnB =delegateReturnHandlerA(10, new CustomData() {CustomDataInt = "delegateReturnHandlerA"});
            
            Console.Write("Delegate returns {0} {1}", returnA, returnB);
            
            #endregion
            
            
            #region Simple Multi Delegate With Returns -----------------------------------------------------------------
            
            //
            //  Setup delegate
            SimpleDelegateReturnHandler delegateReturnHandlerC = new SimpleDelegateReturnHandler(DelegateExamples.SimpleDelegateReturnMethodC);
             
            //
            // Chain delegate in GetInvocationList
           delegateReturnHandlerA += delegateReturnHandlerB + delegateReturnHandlerC;
            
            //
            // Only the last delegate in the invocation list is returned  
            int returnC = delegateReturnHandlerA(12, new CustomData() {CustomDataInt = "delegateReturnHandlerC"});
            
            Console.Write("Multi Delegate returns {0} ", returnC);
           
            #endregion
            
            
            #region Simple EventHandler-------------------------------------------------------------------------------------

            for (int i = 0; i < 1; i++)
            {
                EventExamples eventObj = new EventExamples();
                eventObj.OnSimpleEventHandler();
            }
            #endregion
        }
    }
}
