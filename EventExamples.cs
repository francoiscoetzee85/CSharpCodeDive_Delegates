using System;

namespace CSharpCode
{
    /*------------------------------------------------------------------------------------------------------------------
    Event are notifications to subscriber , common use case are buttons.
    Multiple object and be listing for an event, but they have to subscribe to the event.
    Event can also contain arg that can be routed between objects (eventArgs).
    Icon is lightning bolt 
    Event Raiser (Event) ----- Delegates -----> Event Listener (Event Handler).
    Invocation list is the list of objects listening from an event
    Event Handlers are responsible for receive and processing data from delegates. Usually two 
    parameters ( sender, eventArgs ) .
    EventArg are for encapsulating event data.
    Event are friendly wrappers around delegates 
    Delegates attach to events, need to make sure a delegates is not null
    Event can be cast back to the delegate 
    ------------------------------------------------------------------------------------------------------------------*/



    /// <summary>
    /// Events examples
    /// </summary>
    public class EventExamples
    {

        #region Simple Event -------------------------------------------------------------------------------------------

        //
        // Define an event, stub is public void Event Delegate EventName ;
        public event SimpleDelegateHandler SimpleEvent;

        //
        // Define the event method
        protected virtual void OnSimpleEventA(int dataInt, CustomData dataCus)
        {

            //
            // Only in invoke if a lister is attached ie the delegate is not null
            SimpleEvent?.Invoke(dataInt, dataCus);

            Console.Write("Running Event A : {0} : {1}  {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);


            OnSimpleEventExplicit(dataInt, dataCus);
        }

        #endregion


        #region Simple Event Explicite Syntax---------------------------------------------------------------------------

        //
        // Define an event, stub is public void Event Delegate EventName ;
        public event SimpleDelegateHandler SimpleEventExplicite;

        //
        // Define the event method
        protected virtual void OnSimpleEventExplicit(int dataInt, CustomData dataCus)
        {
            //
            // Explicit syntax, casting back to the delegate and null check on delegate to make sure it invoked
            SimpleDelegateHandler del = SimpleEventExplicite as SimpleDelegateHandler;

            if (del != null)
            {
                //
                // Raise event
                del(dataInt, dataCus);
            }

            Console.Write("Running Event A : {0} : {1}  {2}", dataInt, dataCus.CustomDataInt, Environment.NewLine);
        }

        #endregion


        #region Simple EventHandler-------------------------------------------------------------------------------------

        //
        // Define an event, stub is public void Event Delegate EventName ;
        // EventHandler under the hood is public delegate void EventHandler( object sender, EventArgs args) 
        public event EventHandler SimpleEventHandler;

        //
        // Define the eventHandler method
        public virtual void OnSimpleEventHandler()
        {
            SimpleEventHandler?.Invoke(this, EventArgs.Empty);
            
            Console.Write("Running Event  : OnSimpleEventHandler ", Environment.NewLine);
        }

        #endregion


        #region Simple EventHandler Explicite Syntax--------------------------------------------------------------------

        //
        // Define an event, stub is public void Event Delegate EventName ;
        // EventHandler under the hood is public delegate void EventHandler( object sender, EventArgs args) 
        public event EventHandler SimpleEventHandlerExplicite;

        //
        // Define the eventHandler method
        protected virtual void OnSimpleEventHandlerExplicite()
        {
            var del = SimpleEventHandlerExplicite as EventHandler;
            if (del != null)
            {
                del(this, EventArgs.Empty);
            }
            
            Console.Write("Running Event  : OnSimpleEventHandlerExplicite ", Environment.NewLine);
        }

        #endregion
    }
}
