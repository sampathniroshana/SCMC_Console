using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace EmailCommunicator
{
    class NLP
    {
        private string mModelPath;
        private OpenNLP.Tools.SentenceDetect.MaximumEntropySentenceDetector mSentenceDetector;
        private OpenNLP.Tools.Tokenize.EnglishMaximumEntropyTokenizer mTokenizer;
        private OpenNLP.Tools.PosTagger.EnglishMaximumEntropyPosTagger mPosTagger;
        private OpenNLP.Tools.Chunker.EnglishTreebankChunker mChunker;
        private OpenNLP.Tools.Parser.EnglishTreebankParser mParser;
        private OpenNLP.Tools.NameFind.EnglishNameFinder mNameFinder;
     


            public NLP()
            {
                //mModelPath =
                string appPath = AppDomain.CurrentDomain.BaseDirectory;
                mModelPath = appPath +  @"\Models\";
            }



        public StringBuilder ProcessNlp(String token)

        {
            try
            {
                StringBuilder output = new StringBuilder();

                string[] sentences = SplitSentences(token);

                foreach (string sentence in sentences)
                {
                    output.Append(ParseSentence(sentence).Show()).Append("\r\n\r\n");
                }
                return output;
               

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message.ToString());
                return null;
            }
            //txtOut.Text = output.ToString();
          
        }

        private string[] SplitSentences(string paragraph)
		{
			if (mSentenceDetector == null)
			{
				mSentenceDetector = new OpenNLP.Tools.SentenceDetect.EnglishMaximumEntropySentenceDetector(mModelPath + "EnglishSD.nbin");
			}

			return mSentenceDetector.SentenceDetect(paragraph);
		}

        private OpenNLP.Tools.Parser.Parse ParseSentence(string sentence)
		{
			if (mParser == null)
			{
				mParser = new OpenNLP.Tools.Parser.EnglishTreebankParser(mModelPath, true, false);
			}

			return mParser.DoParse(sentence);
		}
    }
}
