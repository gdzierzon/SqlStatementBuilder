using System.Collections.Generic;

namespace SqlStatementBuilder.Statements.DML
{

    public abstract class DmlStatement
    {
        protected string Action { get; set; }
        protected string TableName { get; set; }
        protected List<object> TableColumns { get; set; }
        protected List<string> Conditions { get; set; }

        protected DmlStatement(string action)
        {
            Action = action;
            TableColumns = new List<object>();
            Conditions = new List<string>();
        }

        protected void InsertColumns(params object[] columns)
        {
            foreach (var column in columns)
            {
                TableColumns.Add(column);
            }
        }
        
        protected void AddCondition(string condition)
        {
            Conditions.Add(condition);
        }

        #region Conditions

        public DmlStatement Where(string condition)
        {
            AddCondition($"WHERE {condition}");
            return this;
        }

        public DmlStatement WhereNot(string condition)
        {
            AddCondition($"WHERE NOT {condition}");
            return this;
        }

        public DmlStatement And(string condition)
        {
            AddCondition($"AND {condition}");
            return this;
        }

        public DmlStatement AndNot(string condition)
        {
            AddCondition($"AND NOT {condition}");
            return this;
        }

        public DmlStatement Or(string condition)
        {
            AddCondition($"OR {condition}");
            return this;
        }

        public DmlStatement OrNot(string condition)
        {
            AddCondition($"OR NOT {condition}");
            return this;
        }

        #endregion

        #region Conditions

        public DmlStatement Where(params string[] conditions)
        {
            var condition = string.Join(" ", conditions);
            AddCondition($"WHERE ({condition})");
            return this;
        }

        public DmlStatement WhereNot(params string[] conditions)
        {
            var condition = string.Join(" ", conditions);
            AddCondition($"WHERE NOT ({condition})");
            return this;
        }

        public DmlStatement And(params string[] conditions)
        {
            var condition = string.Join(" ", conditions);
            AddCondition($"AND ({condition})");
            return this;
        }

        public DmlStatement AndNot(params string[] conditions)
        {
            var condition = string.Join(" ", conditions);
            AddCondition($"AND NOT ({condition})");
            return this;
        }

        public DmlStatement Or(params string[] conditions)
        {
            var condition = string.Join(" ", conditions);
            AddCondition($"OR ({condition})");
            return this;
        }

        public DmlStatement OrNot(params string[] conditions)
        {
            var condition = string.Join(" ", conditions);
            AddCondition($"OR NOT ({condition})");
            return this;
        }

        #endregion

    }
}
