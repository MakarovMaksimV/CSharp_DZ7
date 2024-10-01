using System;
namespace DZ7
{
	[AttributeUsage(AttributeTargets.Property)]
	public class CustomAttribute : Attribute
	{
		
		public string CustomName { get; }

        public CustomAttribute()
        {

        }

        public CustomAttribute(string CustomName)
		{
			this.CustomName = CustomName;
		}

	}
}

