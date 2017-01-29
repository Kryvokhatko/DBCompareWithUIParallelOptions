using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using System;
using System.Diagnostics;

namespace DBCompareWithUIParallelOptions.HelperClass
{
    public class MainTestLogicClass : TestBaseClass
    {
        public void MainTest(string externalId)
        {
            driver = TestInitialize();
            //marker to be notified if method fell down
            bool testFailFlag = false;

            //Check №1 - verify if STAGING.externalId = CollectSM.internalId than continue testing
            InfoFromDB corresponding = new InfoFromDB();
            //get internalId
            string internalId = corresponding.checkIfExternalIdCorrespondsInternalId(externalId);

            if (string.IsNullOrEmpty(corresponding.checkIfExternalIdCorrespondsInternalId(externalId)))
            {
                testFailFlag = true;
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.WriteLine(" для этого externalId нет соответствующего internalId в CollectSM.TRANSIT_MASTERLINKS", externalId);
                return;
            }

            //
            //compare data from table STAGING_TRANSIT_AGREEMS with interface data
            //
            //find client by internalId in interface
            Interfaces interfaces = new Interfaces(driver);
            interfaces.SearchByInternalIdInterface(internalId);

            //compare data for the table field AGREEMNUMBER
            interfaces.compareAgreemnumber(externalId);

            //compare data for the table field AGREEMID
            interfaces.compareAGREEMID(externalId);

            //compare data for the table field ACCOUNTNUMBER
            interfaces.compareAccountnumber(externalId);

            //compare data for the table field OPENEDDATE
            interfaces.compareOPENEDDATE(externalId);

            //compare data for the table field PLANEDCLOSEDATE
            interfaces.comparePlanedCloseDate(externalId);

            //compare data for the table field CREDITSUM
            interfaces.compareCreditsum(externalId);

            //compare data for the table field SUBPRODUCT
            interfaces.compareSubproduct(externalId);

            //compare data for the table field MAINCURRENCYCODEID
            interfaces.compareCurrencyCodeId(externalId);

            //compare data for the table field BALANCE
            interfaces.compareBalance(externalId);

            //compare data for the table field CURRENTINTEREST
            interfaces.compareCurrentInterest(externalId);

            //compare data for the table field CURRENTCOMMISION
            interfaces.compareCurrentComission(externalId);

            //compare data for the table field OUTSTANDING
            interfaces.compareOutstanding(externalId);

            //Check №2 - to check from what system agreems came 
            int count = corresponding.checkIfClientIdHasAnotherAgreemsInCollectSM(externalId);
            if (count <= 1)
            {
                //
                //compare data from the table STAGING_TRANSIT_PERSONS with interface data
                //
                //compare data for the table field INN
                interfaces.CompareINN(externalId);

                //compare data for the table field LASTNAME
                interfaces.compareLASTNAME(externalId);

                //compare data for the table field FIRSTNAME
                interfaces.compareFIRSTNAME(externalId);

                //compare data for the table field PATRONYMIC
                interfaces.comparePATRONYMIC(externalId);

                //compare data for the table field BIRTHDAY
                interfaces.compareBIRTHDAY(externalId);

                //compare data for the table field FIO
                interfaces.compareFIO(externalId);

                //
                //compare data from the table STAGING_TRANSIT_DELINQUENCY with interface data
                //
                //compare data for the table field DPD
                interfaces.compareDPD(externalId);

                //compare data for the table field AMTOVERDUEDEBT
                interfaces.compareAMTOVERDUEDEBT(externalId);

                //compare data for the table field AMTOVERDUEINTEREST
                interfaces.compareAMTOVERDUEINTEREST(externalId);

                //compare data for the table field AMTOVERDUECOMMISION
                interfaces.compareAMTOVERDUECOMMISION(externalId);

                //compare data for the table field PENALTY
                interfaces.comparePENALTY(externalId);

                //compare data for the table field TOTALARREARSVALUE
                interfaces.compareTOTALARREARSVALUE(externalId);
            }

            //compare phone numbers
            interfaces.comparePhones(externalId);

            //check marker
            Assert.IsTrue(!testFailFlag);
            TestCleanUp();
        }
    }
}
