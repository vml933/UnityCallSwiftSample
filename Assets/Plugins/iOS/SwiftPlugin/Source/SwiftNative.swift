//
//  SwiftNative.swift
//  SwiftPlugin
//
//  Created by WEN WEI LIN on 2019/1/21.
//  Copyright © 2019 WEN WEI LIN. All rights reserved.
//

import Foundation
import UIKit

@objc public class SwiftNative:NSObject{
    
    @objc static public let shared = SwiftNative()
    
    @objc public func myFunction(){
        print("hihi i'm swift")
        
        let alert = UIAlertController(title: "title", message: "msg", preferredStyle: .alert)
        let action = UIAlertAction(title: "ok", style: .cancel, handler: nil)
        alert.addAction(action)
        
        UIApplication.shared.keyWindow?.rootViewController?.present(alert, animated: true, completion: nil)

    }
}
