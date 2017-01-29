using System;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Diagnostics;

namespace DBCompareWithUIParallelOptions.HelperClass
{
    public class Interfaces : TestBaseClass
    {
        InfoFromDB corresponding = new InfoFromDB();
        private string externalId;
        private bool testFail;
        public IWebDriver driver;
        public Interfaces(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void SearchByInternalIdInterface(string internalId)
        {
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromMilliseconds(1000));
            driver.FindElement(By.Id("search-term")).Clear();
            driver.FindElement(By.Id("search-term")).SendKeys(internalId);
            driver.FindElement(By.Id("search-term")).Submit();
        }

        //
        //compare data from table STAGING_TRANSIT_AGREEMS with interface
        //
        //compare field AGREEMNUMBER
        public void compareAgreemnumber(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            if (!string.IsNullOrEmpty(tableTransit_Agreems[2]))
            {
                string textFromTransit_AgreemsAgreemnumber = tableTransit_Agreems[2];
                string agreementNumber = driver.FindElement(By.Id("agreementNumber")).Text;
                char[] charToTrim = { '#' };
                string textFromUIAgreemNumber = agreementNumber.Trim(charToTrim);
                var compareAgreemnumber = String.Equals(textFromUIAgreemNumber, textFromTransit_AgreemsAgreemnumber);
                if (compareAgreemnumber != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля AGREEMNUMBER в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field AGREEMID
        public void compareAGREEMID(string externalId)
        {
            string textFromTransit_AgreemId = corresponding.checkIfExternalIdCorrespondsInternalId(externalId);
            if (!string.IsNullOrEmpty(textFromTransit_AgreemId))
            {
                string textFromUIAgreemId = driver.FindElement(By.Id("agreementId")).Text;
                var compareAGREEMID = String.Equals(textFromUIAgreemId, textFromTransit_AgreemId);
                if (compareAGREEMID != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля AGREEMID в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field ACCOUNTNUMBER
        public void compareAccountnumber(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            double textFromTransit_AgreemsAccountnumber = 0;
            if (!string.IsNullOrEmpty(tableTransit_Agreems[3]))
            {
                double textDouble = Convert.ToDouble(tableTransit_Agreems[3]);
                textFromTransit_AgreemsAccountnumber = Convert.ToDouble(Math.Ceiling(textDouble));
                double textFromUIAccountNumber = Convert.ToDouble(driver.FindElement(By.Id("agreementAccount")).Text);
                var compareAccountnumber = Double.Equals(textFromUIAccountNumber, textFromTransit_AgreemsAccountnumber);
                if (compareAccountnumber != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля ACCOUNTNUMBER в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //сcompare field OPENEDDATE
        public void compareOPENEDDATE(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            string textFromTransit_AgreemsOpenedDate = null;
            if (!string.IsNullOrEmpty(tableTransit_Agreems[4]))
            {
                textFromTransit_AgreemsOpenedDate = DateTime.Parse(tableTransit_Agreems[4]).ToShortDateString();
                string textFromUIOpenDate = driver.FindElement(By.Id("agreementOpen")).Text;
                var compareOPENEDDATE = String.Equals(textFromUIOpenDate, textFromTransit_AgreemsOpenedDate);
                if (compareOPENEDDATE != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля OPENEDDATE в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field PLANEDCLOSEDATE
        public void comparePlanedCloseDate(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            string textFromTransit_AgreemsPlanedCloseDate = null;
            if (!string.IsNullOrEmpty(tableTransit_Agreems[5]))
            {
                textFromTransit_AgreemsPlanedCloseDate = DateTime.Parse(tableTransit_Agreems[5]).ToShortDateString();
                string textFromUICloseDate = driver.FindElement(By.Id("agreementClose")).Text;
                var comparePLANEDCLOSEDATE = String.Equals(textFromUICloseDate, textFromTransit_AgreemsPlanedCloseDate);
                if (comparePLANEDCLOSEDATE != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля PLANEDCLOSEDATE в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field CREDITSUM
        public void compareCreditsum(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            string textFromTransit_AgreemsCreditsum = "";
            char[] delimiterChar = { ',', '.' };
            if (!string.IsNullOrEmpty(tableTransit_Agreems[7]))
            {
                textFromTransit_AgreemsCreditsum = tableTransit_Agreems[7].Split(delimiterChar)[0];
                string textFromUI = driver.FindElement(By.Id("agreementAmount")).Text;
                string textFromUICreditsum = textFromUI.Split(delimiterChar)[0];
                var compareCREDITSUM = String.Equals(textFromUICreditsum, textFromTransit_AgreemsCreditsum);
                if (compareCREDITSUM != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля CREDITSUM в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field SUBPRODUCT
        public void compareSubproduct(string externalId)
        {
            string subproductNickName = corresponding.getSubproductName(externalId);
            string text = driver.FindElement(By.Id("agreementProduct")).Text;
            if (!text.Contains('('))
            {
                testFail = true;
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.WriteLine(" поле SUBPRODUCT в Staging_Transit_Agreems не задано, есть продукт но нет сабпродукт!", externalId);
                return;
            }
            var tempText = text.Split('(');
            string textFromUISubProduct = tempText[1].TrimEnd(')');
            var compareSUBPRODUCT = String.Equals(textFromUISubProduct, subproductNickName);
            if (compareSUBPRODUCT != true)
            {
                testFail = true;
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.WriteLine(" поля SUBPRODUCT в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
            }
        }

        //compare field MAINCURRENCYCODEID
        public void compareCurrencyCodeId(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            if (!string.IsNullOrEmpty(tableTransit_Agreems[9]))
            {
                string textFromTransit_AgreemsCurrencyCodeId = tableTransit_Agreems[9];
                if (textFromTransit_AgreemsCurrencyCodeId == "840")
                {
                    textFromTransit_AgreemsCurrencyCodeId = "USD";
                }
                else if (textFromTransit_AgreemsCurrencyCodeId == "980")
                {
                    textFromTransit_AgreemsCurrencyCodeId = "UAH";
                }
                else if (textFromTransit_AgreemsCurrencyCodeId == "978")
                {
                    textFromTransit_AgreemsCurrencyCodeId = "EUR";
                }
                else if (textFromTransit_AgreemsCurrencyCodeId == "826")
                {
                    textFromTransit_AgreemsCurrencyCodeId = "GBP";
                }
                else if (textFromTransit_AgreemsCurrencyCodeId == "756")
                {
                    textFromTransit_AgreemsCurrencyCodeId = "CHF";
                }
                else if (textFromTransit_AgreemsCurrencyCodeId == "643")
                {
                    textFromTransit_AgreemsCurrencyCodeId = "RUB";
                }
                string textFromUICurrency = driver.FindElement(By.Id("agreementCurrency")).Text;
                var compareMAINCURRENCYCODEID = String.Equals(textFromUICurrency, textFromTransit_AgreemsCurrencyCodeId);
                if (compareMAINCURRENCYCODEID != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля MAINCURRENCYCODEID в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field BALANCE
        public void compareBalance(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            double textFromTransit_AgreemsBalance = 0;
            if (!string.IsNullOrEmpty(tableTransit_Agreems[16]))
            {
                double textDouble = Convert.ToDouble(tableTransit_Agreems[16]);
                textFromTransit_AgreemsBalance = Convert.ToDouble(Math.Ceiling(textDouble));
                var textFromUI = driver.FindElement(By.ClassName("col-sm-4"));
                double textFromUIBalance = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[1].Text);
                var compareBALANCE = Double.Equals(textFromUIBalance, textFromTransit_AgreemsBalance);
                if (compareBALANCE != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля BALANCE в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field CURRENTINTEREST
        public void compareCurrentInterest(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            double textFromTransit_AgreemsCurrentinterest = 0;
            if (!string.IsNullOrEmpty(tableTransit_Agreems[17]))
            {
                double textDouble = Convert.ToDouble(tableTransit_Agreems[17]);
                textFromTransit_AgreemsCurrentinterest = Convert.ToDouble(Math.Ceiling(textDouble));
                var textFromUI = driver.FindElement(By.ClassName("col-sm-4"));
                double textFromUICurrentinterrest = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[2].Text);
                var compareCURRENTINTEREST = Double.Equals(textFromUICurrentinterrest, textFromTransit_AgreemsCurrentinterest);
                if (compareCURRENTINTEREST != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля CURRENTINTEREST в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field CURRENTCOMMISION
        public void compareCurrentComission(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            double textFromTransit_AgreemsCurrentcomission = 0;
            if (!string.IsNullOrEmpty(tableTransit_Agreems[18]))
            {
                double textDouble = Convert.ToDouble(tableTransit_Agreems[18]);
                textFromTransit_AgreemsCurrentcomission = Convert.ToDouble(Math.Ceiling(textDouble));
                var textFromUI = driver.FindElement(By.ClassName("col-sm-4"));
                double textFromUICurrentcomission = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[3].Text);
                var compareCURRENTCOMMISION = Double.Equals(textFromUICurrentcomission, textFromTransit_AgreemsCurrentcomission);
                if (compareCURRENTCOMMISION != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля CURRENTCOMMISION в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //compare field OUTSTANDING
        public void compareOutstanding(string externalId)
        {
            var tableTransit_Agreems = corresponding.getDataFromStaging_Transit_Agreems(externalId);
            double textFromTransit_AgreemsOutstanding = 0;
            if (!string.IsNullOrEmpty(tableTransit_Agreems[20]))
            {
                double textDouble = Convert.ToDouble(tableTransit_Agreems[20]);
                textFromTransit_AgreemsOutstanding = Convert.ToDouble(Math.Ceiling(textDouble));
                var textFromUI = driver.FindElement(By.ClassName("col-sm-4"));
                double textFromUIOutstanding = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[0].Text);
                var compareBALANCE = Double.Equals(textFromUIOutstanding, textFromTransit_AgreemsOutstanding);
                if (compareBALANCE != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля OUTSTANDING в интерфейсе и Staging_Transit_Agreems не совпадают!", externalId);
                }
            }
        }

        //
        //compare data from table STAGING_TRANSIT_PERSONS with interface (count > 1)
        //
        //compare field INN
        public void CompareINN(string externalId)
        {
            var tableTransit_Persons = corresponding.getDataFromStaging_Transit_Persons(externalId);
            if (tableTransit_Persons.Count == 0)
            {
                return;
            }
            string textFromTransit_PersonsINN = null;
            if (!string.IsNullOrEmpty(tableTransit_Persons[1]))
            {
                textFromTransit_PersonsINN = tableTransit_Persons[1];
                string textFromUIINN = driver.FindElement(By.Id("clientIdentificationNumber")).Text;
                var compareINN = String.Equals(textFromUIINN, textFromTransit_PersonsINN);
                if (compareINN != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля INN в интерфейсе и Staging_Transit_Persons не совпадают!", externalId);
                }
            }
        }

        //compare field LASTNAME
        public void compareLASTNAME(string externalId)
        {
            var tableTransit_Persons = corresponding.getDataFromStaging_Transit_Persons(externalId);
            if (tableTransit_Persons.Count == 0)
            {
                return;
            }
            string textFromTransit_PersonsLastName = null;
            if (!string.IsNullOrEmpty(tableTransit_Persons[2]))
            {
                textFromTransit_PersonsLastName = tableTransit_Persons[2];
                char[] delimiterChars = { ' ' };
                string allFIOText = driver.FindElement(By.Id("client-search")).Text;
                string[] wordsFIO = allFIOText.Split(delimiterChars);
                string textFromUILastName = wordsFIO[0].ToString();
                var compareLASTNAME = String.Equals(textFromUILastName, textFromTransit_PersonsLastName);
                if (compareLASTNAME != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля LASTNAME в интерфейсе и Staging_Transit_Persons не совпадают!", externalId);
                }
            }
            else
            {
                string textFromTransit_PersonsJuridicalName = tableTransit_Persons[13];
                string textFromUIJuridicalName = driver.FindElement(By.Id("client-search")).Text;
                var compareLASTNAME = String.Equals(textFromUIJuridicalName, textFromTransit_PersonsJuridicalName);
                if (compareLASTNAME != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля LASTNAME в интерфейсе и Staging_Transit_Persons для Юридического лица не совпадают!", externalId);
                }
            }
        }

        //compare field FIRSTNAME
        public void compareFIRSTNAME(string externalId)
        {
            var tableTransit_Persons = corresponding.getDataFromStaging_Transit_Persons(externalId);
            if (tableTransit_Persons.Count == 0)
            {
                return;
            }
            string textFromTransit_PersonsFirstName = null;
            if (!string.IsNullOrEmpty(tableTransit_Persons[3]))
            {
                textFromTransit_PersonsFirstName = tableTransit_Persons[3];
                char[] delimiterChars = { ' ' };
                string allFIOText = driver.FindElement(By.Id("client-search")).Text;
                string[] wordsFIO = allFIOText.Split(delimiterChars);
                string textFromUIFirstName = wordsFIO[1].ToString();
                var compareFIRSTNAME = String.Equals(textFromUIFirstName, textFromTransit_PersonsFirstName);
                if (compareFIRSTNAME != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля FIRSTNAME в интерфейсе и Staging_Transit_Persons не совпадают!", externalId);
                }
            }
            else
            {
                string textFromTransit_PersonsJuridicalName = tableTransit_Persons[13];
                string allTextLegalEntity = driver.FindElement(By.Id("client-search")).Text;
                var compareLASTNAME = String.Equals(allTextLegalEntity, textFromTransit_PersonsJuridicalName);
                if (compareLASTNAME != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля FIRSTNAME в интерфейсе и Staging_Transit_Persons для Юридического лица не совпадают!", externalId);
                }
            }
        }

        //compare field PATRONYMIC
        public void comparePATRONYMIC(string externalId)
        {
            var tableTransit_Persons = corresponding.getDataFromStaging_Transit_Persons(externalId);
            if (tableTransit_Persons.Count == 0)
            {
                return;
            }
            string textFromTransit_PersonsPatronymic = null;
            if (!string.IsNullOrEmpty(tableTransit_Persons[4]))
            {
                textFromTransit_PersonsPatronymic = tableTransit_Persons[4];
                char[] delimiterChars = { ' ' };
                string allFIOText = driver.FindElement(By.Id("client-search")).Text;
                string[] wordsFIO = allFIOText.Split(delimiterChars);
                string textFromUIPatronymic = wordsFIO[2].ToString();
                var comparePATRONYMIC = String.Equals(textFromUIPatronymic, textFromTransit_PersonsPatronymic);
                if (comparePATRONYMIC != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля PATRONYMIC в интерфейсе и Staging_Transit_Persons не совпадают!", externalId);
                }
            }
            else
            {
                string textFromTransit_PersonsJuridicalName = tableTransit_Persons[13];
                string allTextLegalEntity = driver.FindElement(By.Id("client-search")).Text;
                var compareLASTNAME = String.Equals(allTextLegalEntity, textFromTransit_PersonsJuridicalName);
                if (compareLASTNAME != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля PATRONYMIC в интерфейсе и Staging_Transit_Persons для Юридического лица не совпадают!", externalId);
                }
            }
        }

        //compare field BIRTHDAY
        public void compareBIRTHDAY(string externalId)
        {
            var tableTransit_Persons = corresponding.getDataFromStaging_Transit_Persons(externalId);
            if (tableTransit_Persons.Count == 0)
            {
                return;
            }
            var text5 = tableTransit_Persons[5].ToString();
            var text2 = tableTransit_Persons[2].ToString();
            var text3 = tableTransit_Persons[3].ToString();
            var text4 = tableTransit_Persons[4].ToString();
            if (!string.IsNullOrEmpty(text5) && !string.IsNullOrEmpty(text2) && !string.IsNullOrEmpty(text3) && !string.IsNullOrEmpty(text4))
            {
                string textFromTransit_PersonsBirthday = DateTime.Parse(text5).ToShortDateString();
                string textFromUIBirthday = driver.FindElement(By.Id("clientBirthDay")).Text;
                var compareBIRTHDAY = String.Equals(textFromUIBirthday, textFromTransit_PersonsBirthday);
                if (compareBIRTHDAY != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля BIRTHDAY в интерфейсе и Staging_Transit_Persons не совпадают!", externalId);
                }
            }
        }

        //compare field FIO
        public void compareFIO(string externalId)
        {
            var tableTransit_Persons = corresponding.getDataFromStaging_Transit_Persons(externalId);
            if (tableTransit_Persons.Count == 0)
            {
                return;
            }
            string ttp = tableTransit_Persons[17];
            if (ttp == "  ")
            {
                return;
            }
            string textFromTransit_PersonsFio = null;
            if (!string.IsNullOrEmpty(tableTransit_Persons[17]))
            {
                textFromTransit_PersonsFio = tableTransit_Persons[17];
                string textFromUIFio = driver.FindElement(By.Id("client-search")).Text;
                var compareFIO = String.Equals(textFromUIFio, textFromTransit_PersonsFio);
                if (compareFIO != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля FIO в интерфейсе и Staging_Transit_Persons не совпадают!", externalId);
                }
            }
        }

        //
        //compare data from table STAGING_TRANSIT_DELINQUENCY with inteface
        //
        //compare field DPD
        public void compareDPD(string externalId)
        {
            var tableTransit_Deliquency = corresponding.getDataFromStaging_Transit_Deliquency(externalId);
            string textFromTransit_DeliquencyDpd = null;
            if (!string.IsNullOrEmpty(tableTransit_Deliquency[3]))
            {
                textFromTransit_DeliquencyDpd = tableTransit_Deliquency[3];
                string textFromUIDpd = driver.FindElement(By.Id("agreementDpd")).Text;
                var compareDPD = String.Equals(textFromUIDpd, textFromTransit_DeliquencyDpd);
                if (compareDPD != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля DPD в интерфейсе и Staging_Transit_Deliquency не совпадают!", externalId);
                }
            }
        }

        //compare field AMTOVERDUEDEBT
        public void compareAMTOVERDUEDEBT(string externalId)
        {
            var tableTransit_Deliquency = corresponding.getDataFromStaging_Transit_Deliquency(externalId);
            if (!string.IsNullOrEmpty(tableTransit_Deliquency[4]))
            {
                double text = Convert.ToDouble(tableTransit_Deliquency[4]);
                double textFromTransit_DeliquencyAmtOverdueDebt = Convert.ToDouble(Math.Ceiling(text));
                var textFromUI = driver.FindElement(By.XPath(".//*[@id='financial']/div[2]/div[2]/fieldset"));
                double textFromUIDeliquencyAmtOverdueDebt = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[1].Text);
                var compareAMTOVERDUEDEBT = Double.Equals(textFromUIDeliquencyAmtOverdueDebt, textFromTransit_DeliquencyAmtOverdueDebt);
                if (compareAMTOVERDUEDEBT != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля AMTOVERDUEDEBT в интерфейсе и Staging_Transit_Deliquency не совпадают!", externalId);
                }
            }
        }

        //compare field AMTOVERDUEINTEREST
        public void compareAMTOVERDUEINTEREST(string externalId)
        {
            var tableTransit_Deliquency = corresponding.getDataFromStaging_Transit_Deliquency(externalId);
            if (!string.IsNullOrEmpty(tableTransit_Deliquency[5]))
            {
                double text = Convert.ToDouble(tableTransit_Deliquency[5]);
                double textFromTransit_DeliquencyAmtOverdueInterest = Convert.ToDouble(Math.Ceiling(text));
                var textFromUI = driver.FindElement(By.XPath(".//*[@id='financial']/div[2]/div[2]/fieldset"));
                double textFromUIDeliquencyAmtOverdueInterest = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[2].Text);
                var compareAMTOVERDUEINTEREST = Double.Equals(textFromUIDeliquencyAmtOverdueInterest, textFromTransit_DeliquencyAmtOverdueInterest);
                if (compareAMTOVERDUEINTEREST != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля AMTOVERDUEINTEREST в интерфейсе и Staging_Transit_Deliquency не совпадают!", externalId);
                }
            }
        }

        //compare field AMTOVERDUECOMMISION
        public void compareAMTOVERDUECOMMISION(string externalId)
        {
            var tableTransit_Deliquency = corresponding.getDataFromStaging_Transit_Deliquency(externalId);
            if (!string.IsNullOrEmpty(tableTransit_Deliquency[6]))
            {
                double text = Convert.ToDouble(tableTransit_Deliquency[6]);
                double textFromTransit_DeliquencyAmtOverdueComission = Convert.ToDouble(Math.Ceiling(text));
                var textFromUI = driver.FindElement(By.XPath(".//*[@id='financial']/div[2]/div[2]/fieldset"));
                double textFromUIDeliquencyAmtOverdueComission = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[3].Text);
                var compareAMTOVERDUECOMMISION = Double.Equals(textFromUIDeliquencyAmtOverdueComission, textFromTransit_DeliquencyAmtOverdueComission);
                if (compareAMTOVERDUECOMMISION != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля AMTOVERDUECOMMISION в интерфейсе и Staging_Transit_Deliquency не совпадают!", externalId);
                }
            }
        }

        //compare field PENALTY
        public void comparePENALTY(string externalId)
        {
            var tableTransit_Deliquency = corresponding.getDataFromStaging_Transit_Deliquency(externalId);
            if (!string.IsNullOrEmpty(tableTransit_Deliquency[7]))
            {
                double text = Convert.ToDouble(tableTransit_Deliquency[7]);
                double textFromTransit_DeliquencyPenalty = Convert.ToDouble(Math.Ceiling(text));
                var textFromUI = driver.FindElement(By.XPath(".//*[@id='financial']/div[2]/div[2]/fieldset"));
                double textFromUIDeliquencyPenalty = Convert.ToDouble(textFromUI.FindElements(By.TagName("span"))[4].Text);
                var comparePENALTY = Double.Equals(textFromUIDeliquencyPenalty, textFromTransit_DeliquencyPenalty);
                if (comparePENALTY != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля PENALTY в интерфейсе и Staging_Transit_Deliquency не совпадают!", externalId);
                }
            }
        }

        //compare field TOTALARREARSVALUE
        public void compareTOTALARREARSVALUE(string externalId)
        {
            var tableTransit_Deliquency = corresponding.getDataFromStaging_Transit_Deliquency(externalId);
            if (!string.IsNullOrEmpty(tableTransit_Deliquency[14]))
            {
                double text = Convert.ToDouble(tableTransit_Deliquency[14]);
                double textFromTransit_DeliquencyTotalarrearsValue = Convert.ToDouble(Math.Ceiling(text));
                double textFromUIDeliquencyTotalarrearsValue = Convert.ToDouble(driver.FindElement(By.Id("due-amount")).Text);
                var compareTOTALARREARSVALUE = Double.Equals(textFromUIDeliquencyTotalarrearsValue, textFromTransit_DeliquencyTotalarrearsValue);
                if (compareTOTALARREARSVALUE != true)
                {
                    testFail = true;
                    Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                    Trace.WriteLine(" поля TOTALARREARSVALUE в интерфейсе и Staging_Transit_Deliquency не совпадают!", externalId);
                }
            }
        }

        //compare field Телефонов
        public void comparePhones(string externalId)
        {
            //get all phone masks
            var phoneMask = PhoneCheck.GetPhoneMasks(corresponding);
            //get all phone numbers from STAGING.TRANSIT_CONTACTS_PHONES for the current externalId(agreemid)
            var tableTransit_Contacts_Phones = corresponding.getDataFromStaging_Transit_Contacts_Phones(externalId);
            if (tableTransit_Contacts_Phones.Count == 0)
            {
                return;
            }
            //chech each number STAGING.TRANSIT_CONTACTS_PHONES in logic
            List<string> phonesFromTable = new List<string>();
            foreach (var phone in tableTransit_Contacts_Phones)
            {
                //logic from PhoneCheck
                var phoneNumber = Convert.ToString(phone);
                var ee = PhoneCheck.checkPhoneNumber(phoneNumber, phoneMask);
                if (ee != null)
                {
                    phonesFromTable.Add(ee);
                }
            }
            //all phones from interface
            driver.FindElement(By.Id("phone-header")).Click();
            var baseTable = driver.FindElement(By.TagName("tbody"));
            var tableRows = baseTable.FindElements(By.ClassName("Phone_td")).ToArray();
            int i = 0;
            List<string> phonesFromUI = new List<string>();
            while (i < tableRows.Count())
            {
                string tr = tableRows[i].Text;
                phonesFromUI.Add(tr);
                i++;
            }
            //cmpare phonesFromUI with phonesFromTable
            var contains = phonesFromTable.Intersect(phonesFromUI).Any();
            if (!contains == true && phonesFromUI == null)
            {
                testFail = true;
                Trace.Listeners.Add(new TextWriterTraceListener(Console.Out));
                Trace.WriteLine("телефоны не совпадают!", externalId);
            }
        }
    }
}
