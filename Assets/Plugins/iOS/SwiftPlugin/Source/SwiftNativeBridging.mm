//
//  SwiftNativeBridging.m
//  SwiftPlugin
//
//  Created by WEN WEI LIN on 2019/1/21.
//  Copyright © 2019 WEN WEI LIN. All rights reserved.
//

#import <Foundation/Foundation.h>
#include "SwiftPlugin-Swift.h"

extern "C" {
    void myFunc(){
        [[SwiftNative shared]myFunction];
    }    
}
