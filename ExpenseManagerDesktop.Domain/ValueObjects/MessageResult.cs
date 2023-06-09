﻿using ExpenseManagerDesktop.Domain.Enums;

namespace ExpenseManagerDesktop.Domain.ValueObjects
{
    public class MessageResult
    {
        public string Key { get; set; }
        public string Message { get; set; }
        public MessageType Type { get; set; }
        /// <summary>
        /// Destinado para usar em alerts
        /// </summary>
        public string TypeCustom { get; set; }
    }
}
