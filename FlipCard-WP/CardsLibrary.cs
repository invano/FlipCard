using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FlipCard_WP
{
    
    class CardsLibrary
    {
        public List<Card> CommonCardsInLibrary;
        public List<Card> SilverCardsInLibrary;
        public List<Card> GoldCardsInLibrary;

        public CardsLibrary(String libraryName)
        {
            List<Card> tmpCommonList = List<Card>(Const.APPROXIMATE_CARDSNUMBER);
            List<Card> tmpSilverList = List<Card>(Const.APPROXIMATE_CARDSNUMBER);
            List<Card> tmpGoldList = List<Card>(Const.APPROXIMATE_CARDSNUMBER);
		
		/*NSString *path = [[NSBundle mainBundle] pathForResource:resourceName ofType:@"plist"];
		NSDictionary *cardsInfoDictionary = [NSDictionary dictionaryWithContentsOfFile:path];
		NSDictionary *singleCardInfo;
		NSEnumerator *enumerator = [cardsInfoDictionary objectEnumerator];
		while (singleCardInfo = [enumerator nextObject]) {
			Card *tmpCard = [[Card alloc] initWithDictionaryData:singleCardInfo];
            if([tmpCard.rarity isEqualToString:@"Common"]){
                [tmpCommonList addObject:tmpCard];
            } else if ([tmpCard.rarity isEqualToString:@"Silver"]) {
                [tmpSilverList addObject:tmpCard];
            } else if ([tmpCard.rarity isEqualToString:@"Gold"]){
                [tmpGoldList addObject:tmpCard];
            }
		}
        _CommonCardsInLibrary = [tmpCommonList copy];
        _SilverCardseInLibrary = [tmpSilverList copy];
        _GoldCardsInLibrary = [tmpGoldList copy];
        */}
    }
}
