namespace Battleship
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.IO;

    using System.Xml;
    using System.Xml.Schema;

    using Microsoft.Win32;

    class SaveLoad
    {
        // XML Stuff - DO NOT DELETE!!!!!
        /*
        private XmlSchema schema;

        private XmlSchemaElement game;
        private XmlSchemaElement player;

        private XmlSchemaElement attackBoard;
        private XmlSchemaElement row;
        private XmlSchemaElement cell;

        private XmlSchemaElement defenseBoard;
        private XmlSchemaElement ship;
        private XmlSchemaElement crewmember;

        private XmlReader reader;
        private XmlReaderSettings settings;

        private void instantiateXmlSchemaElement(out XmlSchemaElement elementToBeInstantiated, string xmlElementName)
        {
            elementToBeInstantiated = new XmlSchemaElement();
            this.schema.Items.Add(elementToBeInstantiated);
            elementToBeInstantiated.Name = xmlElementName;
            elementToBeInstantiated.SchemaTypeName = new XmlQualifiedName("string", xmlElementName);
        }

        void settings_ValidationEventHandler(object sender, System.Xml.Schema.ValidationEventArgs e)
        {
            if (e.Severity == XmlSeverityType.Warning)
            {
                Logger.ConsoleInformation("The following validation warning occurred: " + e.Message);
            }
            else if (e.Severity == XmlSeverityType.Error)
            {
                Logger.ConsoleInformation("The following critical validation errors occurred: " + e.Message);
                Type objectType = sender.GetType();
            }
        }

        private string generateXMLSchema()
        {
            string xmlSchema =
                "<?xml version=\"1.0\" encoding=\"utf-8\"?> " +
                "<xs:schema attributeFormDefault=\"unqualified\" " +
                "elementFormDefault=\"qualified\" targetNamespace=\"http://www.contoso.com/books\" " +
                "xmlns:xs=\"http://www.w3.org/2001/XMLSchema\"> " +
                "<xs:element name=\"books\"> " +
                "<xs:complexType> " +
                "<xs:sequence> " +
                "<xs:element maxOccurs=\"unbounded\" name=\"book\"> " +
                "<xs:complexType> " +
                "<xs:sequence> " +
                "<xs:element name=\"title\" type=\"xs:string\" /> " +
                "<xs:element name=\"price\" type=\"xs:decimal\" /> " +
                "</xs:sequence> " +
                "<xs:attribute name=\"genre\" type=\"xs:string\" use=\"required\" /> " +
                "<xs:attribute name=\"publicationdate\" type=\"xs:date\" use=\"required\" /> " +
                "<xs:attribute name=\"ISBN\" type=\"xs:string\" use=\"required\" /> " +
                "</xs:complexType> " +
                "</xs:element> " +
                "</xs:sequence> " +
                "</xs:complexType> " +
                "</xs:element> " +
                "</xs:schema> ";
            return xmlSchema;
        }

        public SaveLoad()
        {
            // Instantiates the schema for the XML document structure.
            this.schema = new XmlSchema();

            this.instantiateXmlSchemaElement(out game, "game");
            this.instantiateXmlSchemaElement(out player, "player");

            this.instantiateXmlSchemaElement(out attackBoard, "attackBoard");
            this.instantiateXmlSchemaElement(out row, "row");
            this.instantiateXmlSchemaElement(out cell, "cell");

            this.instantiateXmlSchemaElement(out defenseBoard, "defenseBoard");
            this.instantiateXmlSchemaElement(out ship, "ship");
            this.instantiateXmlSchemaElement(out crewmember, "crewmember");

            this.settings.Schemas.Add(this.schema);

            this.settings.ValidationEventHandler += this.settings_ValidationEventHandler;
            this.settings.ValidationFlags = this.settings.ValidationFlags | XmlSchemaValidationFlags.ReportValidationWarnings;
            this.settings.ValidationType = ValidationType.Schema;

            try
            {
                reader = XmlReader.Create("schema.xml", this.settings);
            }
            catch (System.IO.FileNotFoundException)
            {
                string xml = generateXMLString();
                byte[] byteArray = Encoding.UTF8.GetBytes(xml);
                MemoryStream stream = new MemoryStream(byteArray);
                reader = XmlReader.Create(stream, settings);
            }
        }
        */

        // start of load function
        // Generate new game (Later set GameID to what was loaded)
        // Pull info from file, seperate into seperate arrays
        // loadedP1DefenceArray, etc...
        // P1DefenceArray = loadedP1DefenceArray
        // or
        // foreach entry in loadedP1DefenceArray
        //  temp = loadedP1DefenceArray[x,y]
        //  P1DDefenceArray = temp
        //  x++
        //  y++

        private List<string> readFile()
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            List<string> fileContents = new List<string>();

            using (StreamReader sr = new StreamReader(dialog.FileName))
            {
                while (sr.Peek() >= 0)
                {
                    fileContents.Add(sr.ReadLine());
                }
            }

            return fileContents;
        }

        private string writeFile(List<string> fileContents)
        {
            OpenFileDialog dialog = new OpenFileDialog();

            dialog.FileName = "Game";
            dialog.DefaultExt = ".csv";
            dialog.Filter = "Battleship Game File (.csv)|*.csv";
            dialog.InitialDirectory = @"C:\";

            using (StreamWriter sw = new StreamWriter(dialog.FileName))
            {
                while(!sw.)
            }
        }

        public SaveLoad()
        {
            string fileContents = this.readFile();
        }
    }
}
