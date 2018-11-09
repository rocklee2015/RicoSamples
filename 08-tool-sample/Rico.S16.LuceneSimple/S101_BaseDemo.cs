using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.Search;
using Lucene.Net.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rico.S16.LuceneSimple
{
    public class S101_BaseDemo
    {
        public static void Excute()
        {
           

            //写入数据到索引
            Analyzer analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
            /*
             * 分析器是用来做词法分析的，包括英文分析器和中文分析器等。要根据所要建立索引的文件情况选择恰当的分析器
             * StandardAnalyzer:标准分析器；
             * CJKAnalyzer:二分法分词器；
             * ChineseAnalyzer:中文分析器；
             * FrenchAnalyzer:法语分析器；
             * 可惜Lucene.net只有StandardAnalyzer分词器，要实现其他分词要配合上其他第三方分词器使用.
             * 通过建立IndexWriter,就把逻辑索引和物理索引联系起来了，这样就可以很方便地建立索引。使用二分法分词器来分析字段内容，然后将索引建立在Directory实例的路径中。
             */

            Directory directory = new RAMDirectory();//在内存中建立索引；
            /*
             * RAMDirectory:在内存中建立索引；
             * FSDirectory:在磁盘中建立索引；
             */

            IndexWriter.MaxFieldLength maxFieldLength = new IndexWriter.MaxFieldLength(10000);

            /*
            * Lucene.Net.Store.Directory：存储索引路径的实例；
            * Lucene.Net.Analysis.Analyzer：分析器的实例；
            * Lucene.Net.Index.IndexWriter.MaxFieldLength：可被拆分出最大的词条数量。
            */
            using (IndexWriter writer = new IndexWriter(directory, analyzer, maxFieldLength))
            {
                Document document1 = new Document();
                document1.Add(new Field("Sentence", "刘备", Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(document1);

                Document document2 = new Document();
                document2.Add(new Field("Sentence", "张飞", Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(document2);

                Document document3 = new Document();
                document3.Add(new Field("Sentence", "关羽", Field.Store.YES, Field.Index.ANALYZED));
                writer.AddDocument(document3);

                writer.Optimize();

            }

            //查找
            using (IndexSearcher searcher = new IndexSearcher(directory))
            {
                Term t = new Term("Sentence", "飞");
                Query query = new TermQuery(t);
                TopDocs docs = searcher.Search(query, null, 1000);
                Console.WriteLine(docs.TotalHits);
                Console.WriteLine(docs.ScoreDocs[0].Doc);
                Document doc = searcher.Doc(docs.ScoreDocs[0].Doc);
                Console.WriteLine(doc.Get("Sentence"));
            }
            Console.WriteLine("----------S01 The End---------------");
            Console.ReadKey();
        }
    }
}
