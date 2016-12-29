using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Xml;
using Microsoft.Web.Services3;
using Microsoft.Web.Services3.Design;
using Microsoft.Web.Services3.Security;
using Microsoft.Web.Services3.Security.Tokens;


namespace CustomPolicyAssertions
{
    class CustomSecurityAssertion : SecurityPolicyAssertion
    {
        TokenProvider<X509SecurityToken> serviceX509TokenProviderValue;
        TokenProvider<X509SecurityToken> clientX509TokenProviderValue;

        public TokenProvider<X509SecurityToken> ClientX509TokenProvider
        {
            get
            {
                return clientX509TokenProviderValue;
            }
            set
            {
                clientX509TokenProviderValue = value;
            }
        }

        public TokenProvider<X509SecurityToken> ServiceX509TokenProvider
        {
            get
            {
                return serviceX509TokenProviderValue;
            }
            set
            {
                serviceX509TokenProviderValue = value;
            }
        }


        public CustomSecurityAssertion()
            : base()
        {
        }

        public override SoapFilter CreateClientOutputFilter(FilterCreationContext context)
        {
            return new CustomSecurityClientOutputFilter(this);
        }

        public override SoapFilter CreateClientInputFilter(FilterCreationContext context)
        {
            return new CustomSecurityClientInputFilter(this);
        }

        public override SoapFilter CreateServiceInputFilter(FilterCreationContext context)
        {
            return new CustomSecurityServerInputFilter(this);
        }

        public override SoapFilter CreateServiceOutputFilter(FilterCreationContext context)
        {
            return new CustomSecurityServerOutputFilter(this);
        }


        public override void ReadXml(System.Xml.XmlReader reader, IDictionary<string, Type> extensions)
        {
            if (reader == null)
                throw new ArgumentNullException("reader");
            if (extensions == null)
                throw new ArgumentNullException("extensions");

            bool isEmpty = reader.IsEmptyElement;
            base.ReadAttributes(reader);
            reader.ReadStartElement("CustomSecurityAssertion");

            if (!isEmpty)
            {
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "clientToken")
                {
                    reader.ReadStartElement();
                    reader.MoveToContent();
                    // Get the registed security token provider for X.509 certificate security credentials. 
                    Type type = extensions[reader.Name];
                    object instance = Activator.CreateInstance(type);

                    if (instance == null)
                        throw new InvalidOperationException(String.Format(System.Globalization.CultureInfo.CurrentCulture, "Unable to instantiate policy extension of type {0}.", type.AssemblyQualifiedName));

                    TokenProvider<X509SecurityToken> clientProvider = instance as TokenProvider<X509SecurityToken>;

                    // Read the child elements that provide the details about the client's X.509 certificate. 
                    clientProvider.ReadXml(reader, extensions);
                    this.ClientX509TokenProvider = clientProvider;
                    reader.ReadEndElement();
                }
                if (reader.MoveToContent() == XmlNodeType.Element && reader.Name == "serviceToken")
                {
                    reader.ReadStartElement();
                    reader.MoveToContent();

                    // Get the registed security token provider for X.509 certificate security credentials. 
                    Type type = extensions[reader.Name];
                    object instance = Activator.CreateInstance(type);

                    if (instance == null)
                        throw new InvalidOperationException(String.Format(System.Globalization.CultureInfo.CurrentCulture, "Unable to instantiate policy extension of type {0}.", type.AssemblyQualifiedName));

                    TokenProvider<X509SecurityToken> serviceProvider = instance as TokenProvider<X509SecurityToken>;
                    // Read the child elements that provide the details about the Web service's X.509 certificate.
                    serviceProvider.ReadXml(reader, extensions);
                    this.ServiceX509TokenProvider = serviceProvider;
                    reader.ReadEndElement();
                }
                base.ReadElements(reader, extensions);
                reader.ReadEndElement();
            }
        }
        public override IEnumerable<KeyValuePair<string, Type>> GetExtensions()
        {
            // Add the CustomSecurityAssertion custom policy assertion to the list of registered
            // policy extensions.
            List<KeyValuePair<string, Type>> extensions = new List<KeyValuePair<string, Type>>();
            extensions.Add(new KeyValuePair<string, Type>("CustomSecurityAssertion", this.GetType()));
            if (serviceX509TokenProviderValue != null)
            {
                // Add any policy extensions that read child elements of the <serviceToken> element
                // to the list of registered policy extensions.
                IEnumerable<KeyValuePair<string, Type>> innerExtensions = serviceX509TokenProviderValue.GetExtensions();
                if (innerExtensions != null)
                {
                    foreach (KeyValuePair<string, Type> extension in innerExtensions)
                    {
                        extensions.Add(extension);
                    }
                }
            }
            if (clientX509TokenProviderValue != null)
            {
                // Add any policy extensions that read child elements of the <clientToken> element
                // to the list of registered policy extensions.
                IEnumerable<KeyValuePair<string, Type>> innerExtensions = clientX509TokenProviderValue.GetExtensions();
                if (innerExtensions != null)
                {
                    foreach (KeyValuePair<string, Type> extension in innerExtensions)
                    {
                        extensions.Add(extension);
                    }
                }
            }
            return extensions;
        }
        // </snippet16

    }

    class RequestState
    {
        SecurityToken clientToken;
        SecurityToken serverToken;

        public RequestState(SecurityToken cToken, SecurityToken sToken)
        {
            clientToken = cToken;
            serverToken = sToken;
        }

        public SecurityToken ClientToken
        {
            get { return clientToken; }
        }

        public SecurityToken ServerToken
        {
            get { return serverToken; }
        }
    }
    class CustomSecurityServerInputFilter : ReceiveSecurityFilter
    {
        public CustomSecurityServerInputFilter(CustomSecurityAssertion parentAssertion)
            : base(parentAssertion.ServiceActor, false)
        {

        }
        public override void ValidateMessageSecurity(SoapEnvelope envelope, Security security)
        {
            SecurityToken clientToken = null;
            SecurityToken serverToken = null;

            // Ensure incoming SOAP messages are signed and encrypted.
            foreach (ISecurityElement elem in security.Elements)
            {
                if (elem is MessageSignature)
                {
                    MessageSignature sig = (MessageSignature)elem;
                    clientToken = sig.SigningToken;
                }

                if (elem is EncryptedData)
                {
                    EncryptedData enc = (EncryptedData)elem;
                    serverToken = enc.SecurityToken;
                }
            }

            if (clientToken == null || serverToken == null)
                throw new Exception("Incoming message did not meet security requirements");

            RequestState state = new RequestState(clientToken, serverToken);

            envelope.Context.OperationState.Set(state);
        }
    }

    class CustomSecurityServerOutputFilter : SendSecurityFilter
    {

        public CustomSecurityServerOutputFilter(CustomSecurityAssertion parentAssertion)
            : base(parentAssertion.ServiceActor, false)
        {
        }

        public override void SecureMessage(SoapEnvelope envelope, Security security)
        {
            RequestState state = envelope.Context.OperationState.Get<RequestState>();

            // Sign the message with the Web service's security token.
            security.Tokens.Add(state.ServerToken);
            security.Elements.Add(new MessageSignature(state.ServerToken));

            // Encrypt the message with the client's security token.
            security.Elements.Add(new EncryptedData(state.ClientToken));
        }
    }
    class CustomSecurityClientInputFilter : ReceiveSecurityFilter
    {
        public CustomSecurityClientInputFilter(CustomSecurityAssertion parentAssertion)
            : base(parentAssertion.ServiceActor, true)
        {

        }

        public override void ValidateMessageSecurity(SoapEnvelope envelope, Security security)
        {
            RequestState state;
            bool signed = false;
            bool encrypted = false;

            // Get the request state out of the operation state.
            state = envelope.Context.OperationState.Get<RequestState>();

            // Make sure the message was signed with the server's security token.
            foreach (ISecurityElement elem in security.Elements)
            {
                if (elem is MessageSignature)
                {
                    MessageSignature sig = (MessageSignature)elem;

                    if (sig.SigningToken.Equals(state.ServerToken))
                        signed = true;
                }

                if (elem is EncryptedData)
                {
                    EncryptedData enc = (EncryptedData)elem;

                    if (enc.SecurityToken.Equals(state.ClientToken))
                        encrypted = true;
                }
            }

            if (!signed || !encrypted)
                throw new Exception("Response message does not meet security requirements");
        }
    }
    class CustomSecurityClientOutputFilter : SendSecurityFilter
    {
        SecurityToken clientToken;
        SecurityToken serverToken;

        public CustomSecurityClientOutputFilter(CustomSecurityAssertion parentAssertion)
            : base(parentAssertion.ServiceActor, true)
        {
            // Get the client security token.
            clientToken = X509TokenProvider.CreateToken(StoreLocation.CurrentUser, StoreName.My, "CN=WSE2QuickStartClient");

            // Get the server security token.
            serverToken = X509TokenProvider.CreateToken(StoreLocation.LocalMachine, StoreName.My, "CN=WSE2QuickStartServer");
        }

        public override void SecureMessage(SoapEnvelope envelope, Security security)
        {
            // Sign the SOAP message with the client's security token.
            security.Tokens.Add(clientToken);
            security.Elements.Add(new MessageSignature(clientToken));

            // Encrypt the SOAP message with the client's security token.
            security.Elements.Add(new EncryptedData(serverToken));

            // Encrypt the client's security token with the server's security token.
            security.Elements.Add(new EncryptedData(serverToken, "#" + clientToken.Id));

            // Store the client and server security tokens in the request state.
            RequestState state = new RequestState(clientToken, serverToken);

            // Store the request state in the proxy's operation state. 
            // This makes these tokens accessible when SOAP responses are 
            // verified to have sufficient security requirements.
            envelope.Context.OperationState.Set(state);
        }
    }
}