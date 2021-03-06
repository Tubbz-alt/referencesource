// ==++==
//
//   Copyright (c) Microsoft Corporation.  All rights reserved.
//
// ==--==

namespace Microsoft.CSharp.RuntimeBinder.Errors
{
    ////////////////////////////////////////////////////////////////////////////////
    //
    // This is the "controller" for compiler objects. The controller is the object
    // that exposes/implements ICSCompiler for external consumption.  Compiler
    // options are configured through this object, and for an actual compilation,
    // this object instanciates a LangCompiler, feeds it the appropriate information,
    // tells it to compile, and then destroys it.

    internal abstract class CController
    {
        private CErrorFactory m_errorFactory;

        protected CController()
        {
            m_errorFactory = new CErrorFactory();
        }

        ////////////////////////////////////////////////////////////////////////////////
        //
        // This function places a fully-constructed CError object into an error container
        // and sends it to the compiler host (this would be the place to batch these guys
        // up if we decide to.
        //
        // Note that if the error can't be put into a container (if, for example, we
        // can't create a container) the error is destroyed and the host is notified via
        // exception.

        public abstract void SubmitError(CError pError);

        public CErrorFactory GetErrorFactory()
        {
            return m_errorFactory;
        }
    }

}