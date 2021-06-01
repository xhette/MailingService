using System;
using System.Collections.Generic;
using System.Text;

namespace SMSConsumer.Models
{
	public enum SMSResultEnum
	{
		/// <summary>
		/// Сообщение доставлено на телефон
		/// </summary>
		Delivered = 1,

		/// <summary>
		/// Были предприняты попытки доставить сообщение в течение допустимого времени, но срок истек и сообщение не было доставлено
		/// </summary>
		Expired = 2,

		/// <summary>
		/// Сообщение не доставлено на телефон
		/// </summary>
		NotDelivered = 3,

		/// <summary>
		/// Не был получен статус доставки сообщения от оператора связи
		/// </summary>
		Unknown = 4,

		/// <summary>
		/// Получен отказ в передаче от оператора
		/// </summary>
		Rejected = 5,

		/// <summary>
		/// Сообщение было отбито со стороны шлюза
		/// </summary>
		Error = 6
	}
}
