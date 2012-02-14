using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Estime.Web.Util
{
	public abstract class Enumeration : IComparable
	{
		protected Enumeration()
		{
		}

		protected Enumeration(int value, string displayName)
		{
			Value = value;
			DisplayName = displayName;
		}

		public int Value { get; private set; }
		public string DisplayName { get; private set; }

		public override bool Equals(object obj)
		{
			var other = obj as Enumeration;

			if( other==null )
			{
				return false;
			}
			if( ReferenceEquals(this, obj) )
			{
				return true;
			}

			if( GetType()!=obj.GetType() )
			{
				return false;
			}
			return other.Value==Value && Equals(other.DisplayName, DisplayName);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (Value * 397) ^ DisplayName.GetHashCode();
			}
		}

		public static bool operator ==(Enumeration left, Enumeration right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Enumeration left, Enumeration right)
		{
			return !Equals(left, right);
		}

		public static int operator -(Enumeration left, Enumeration right)
		{
			return left.Value - right.Value;
		}

		public int CompareTo(object obj)
		{
			return Value.CompareTo(((Enumeration) obj).Value);
		}

		public static IEnumerable<T> GetAll<T>() where T : Enumeration, new()
		{
			var type = typeof(T);
			var fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly);

			return fields.Select(field => field.GetValue(null)).OfType<T>();
		}

		public static int AbsoluteDifference(Enumeration firstValue, Enumeration secondValue)
		{
			var absoluteDifference = Math.Abs(firstValue - secondValue);
			return absoluteDifference;
		}

		public static T FromValue<T>(int value) where T : Enumeration, new()
		{
			var matchingItem = parse<T, int>(value, "value", x => x.Value==value);
			return matchingItem;
		}

		public static T FromDisplayName<T>(string displayName) where T : Enumeration, new()
		{
			var matchingItem = parse<T, string>(displayName, "display name", x => x.DisplayName==displayName);
			return matchingItem;
		}

		private static T parse<T, K>(K value, string description, Func<T, bool> predicate) where T : Enumeration, new()
		{
			var matchingItem = GetAll<T>().FirstOrDefault(predicate);

			if( matchingItem==null )
			{
				var message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(T));
				throw new InvalidOperationException(message);
			}
			return matchingItem;
		}
	}
}