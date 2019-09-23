using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CaptiveIQTest.SharedObjs;
using Microsoft.AspNetCore.Mvc;

namespace CaptiveIQTest.Server.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        // GET api/User/{id}
        [HttpGet("{id}")]
        public CIQUser Get(string id)
        {
            var userExists = DynamoUtils.EntryExists<CIQUser>(id);
            if (userExists)
            {
                var user = DynamoUtils.GetById<CIQUser>(id);
                return user;
            }
            else
            {
                var user = createNewUser(id);
                var insertResult = user.Insert().Result;
                return user;
            }
        }

        private CIQUser createNewUser(string id)
        {
            var columns = new List<ColumnData>();
            for (var i = 0; i < 10; i++) {
                var emptyColumnData = new ColumnData
                {
                    ColumnLetter = Convert.ToChar(65 + i)
                };
                for (var j = 0; j < 10; j++)
                {
                    emptyColumnData.CellDatas.Add(new CellData());
                }

                columns.Add(emptyColumnData);
            }

            return new CIQUser
            {
                Id = id,
                Columns = columns
            };
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public CIQUser Put(string id, [FromBody] CIQUser user)
        {
            updateUserData(user);
            var insertResult = user.Insert().Result;
            return user;
        }

        private static void updateUserData(CIQUser user)
        {
            foreach (var column in user.Columns)
            {
                for (var i = 0; i < column.CellDatas.Count; i++)
                {
                    var cell = user.GetCell(column.ColumnLetter, i);
                    if (!string.IsNullOrEmpty(cell.Formula))
                    {
                        cell.Data = processCell(user, cell);
                    }
                }
            }
        }

        private static string processCell(CIQUser user, CellData cell) 
        {
            if (cell.Formula[0] != '=')
            {
                return cell.Formula;
            }

            var delimiters = new char[] { '=', '+', '-', '/', '*' };
            var tokens = cell.Formula.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            var sum = 0f;

            // Get operator tokens
            var operators = new List<char>();
            foreach (var c in cell.Formula)
            {
                if (c == '+' || c == '-' || c == '=' || c == '/')
                {
                    operators.Add(c);
                }
            }

            // Process cell index tokens
            for (var i = 0; i < tokens.Length; i++)
            {
                var token = tokens[i];
                var column = token[0];
                var indexStr = token.Substring(1);
                var index = int.Parse(indexStr);
                var additionalCell = user.GetCell(column, index);
                var valueParse = float.TryParse(additionalCell.Data, out var cellValue);
                if (!valueParse)
                {
                    return "N/A";
                }
                if (i == 0)
                {
                    sum = cellValue;
                } 
                else
                {
                    if (operators[i] == '+')
                    {
                        sum += cellValue;
                    }
                    else if (operators[i] == '-')
                    {
                        sum -= cellValue;
                    }
                    else if (operators[i] == '*')
                    {
                        sum *= cellValue;
                    }
                    else if (operators[i] == '/')
                    {
                        sum /= cellValue;
                    }
                    else
                    {
                        return "N/A";
                    }
                }
            }

            return sum.ToString();
        }
    }
}
