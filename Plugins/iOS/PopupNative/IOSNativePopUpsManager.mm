//  Created by PingAK9

#import "IOSNativePopUpsManager.h"

@implementation IOSNativePopUpsManager

+ (void) ShowDialogConfirm: (NSString *) title message: (NSString*) msg yesTitle:(NSString*) b1 noTitle: (NSString*) b2{

    UIAlertController *alertController = [UIAlertController alertControllerWithTitle:title message:msg preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *yesAction = [UIAlertAction actionWithTitle:b1 style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
        [IOSNativePopUpsManager unregisterAllertView];
        UnitySendMessage("MobileDialogConfirm", "OnYesCallBack",  [DataConvertor NSIntToChar:0]);
    }];
    
    UIAlertAction *noAction = [UIAlertAction actionWithTitle:b2 style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
        [IOSNativePopUpsManager unregisterAllertView];
        UnitySendMessage("MobileDialogConfirm", "OnNoCallBack",  [DataConvertor NSIntToChar:1]);
    }];
    
    [alertController addAction:yesAction];
    [alertController addAction:noAction];
    
    [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:alertController animated:YES completion:nil];
}

+(void)ShowDialogInfo: (NSString *) title message: (NSString*) msg okTitle:(NSString*) b1 {
    
    UIAlertController *alertController = [UIAlertController alertControllerWithTitle:title message:msg preferredStyle:UIAlertControllerStyleAlert];
    
    UIAlertAction *okAction = [UIAlertAction actionWithTitle:b1 style:UIAlertActionStyleDefault handler:^(UIAlertAction * _Nonnull action) {
        [IOSNativePopUpsManager unregisterAllertView];
        UnitySendMessage("MobileDialogInfo", "OnOkCallBack",  [DataConvertor NSIntToChar:0]);
    }];
    [alertController addAction:okAction];
    
    [[[[UIApplication sharedApplication] keyWindow] rootViewController] presentViewController:alertController animated:YES completion:nil];
}

extern "C" {
    // Unity Call
    
    void _TAG_ShowDialogConfirm(char* title, char* message, char* yes, char* no) {
        [IOSNativePopUpsManager ShowDialogConfirm:[DataConvertor charToNSString:title] message:[DataConvertor charToNSString:message] yesTitle:[DataConvertor charToNSString:yes] noTitle:[DataConvertor charToNSString:no]];
    }
    
    void _TAG_ShowDialogInfo(char* title, char* message, char* ok) {
        [IOSNativePopUpsManager ShowDialogInfo:[DataConvertor charToNSString:title] message:[DataConvertor charToNSString:message] okTitle:[DataConvertor charToNSString:ok]];
    }
}

@end
