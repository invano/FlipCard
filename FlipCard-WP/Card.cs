using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlipCard_WP
{
    class Card
    {
        public int idNumber;
        public int upValue;
        public int downValue;
        public int leftValue;
        public int rightValue;

        int color;

        int manaType;
        int rarityType;

        public bool isRed()
        {
            return color == Const.RED ? true : false;
        }

        public bool isBlue()
        {
            return color == Const.BLUE ? true : false;
        }

        public void setColor(int color)
        {
            this.color = color;
        }

        public int getColor() {

            return this.color;
        }

        public String description() {
            return "CardId: " + this.idNumber;
        }


        /*
        public void initWithDictionaryData( dataDictionaryInput) {
	self = [self init];
	if (self) {
		_idNumber = (NSNumber *)[dataDictionaryInput valueForKey:@"idNumber"];
		_up = (NSNumber *)[dataDictionaryInput valueForKey:@"up"];
		_down = (NSNumber *)[dataDictionaryInput valueForKey:@"down"];
		_left = (NSNumber *)[dataDictionaryInput valueForKey:@"left"];
		_right = (NSNumber *)[dataDictionaryInput valueForKey:@"right"];
		_rarity = [dataDictionaryInput valueForKey:@"rarity"];
		_manaType = [dataDictionaryInput valueForKey:@"manaType"];
		
		NSString *path1 = [[NSBundle mainBundle] pathForResource:[[NSString alloc] initWithFormat:@"Card%dRed", [_idNumber intValue]] ofType:@"png"]; //or .png?
		_redCardImage = [UIImage imageWithContentsOfFile:path1];
		NSString *path2 = [[NSBundle mainBundle] pathForResource:[[NSString alloc] initWithFormat:@"Card%dBlue", [_idNumber intValue]] ofType:@"png"]; //or .png?
		_blueCardImage = [UIImage imageWithContentsOfFile:path2];
	}
	return self;
}
        */

    }
}
