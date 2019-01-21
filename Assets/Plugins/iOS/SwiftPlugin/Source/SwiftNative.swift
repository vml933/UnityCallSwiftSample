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

    @objc func showAlert(msg:String){
        let alert = createAlert(msg)
        UIApplication.shared.keyWindow?.rootViewController?.present(alert, animated: true, completion: nil)
    }
    
    @objc func toCustomPage(){
        let customPage = createCustomPage()
        UIApplication.shared.keyWindow?.rootViewController?.present(customPage, animated: true, completion: nil)
    }
    
    @objc func getDummyStr()->String{
        return "this is dummy Str"
    }
    
    private func createAlert(_ msg:String)->UIViewController{
        let alert = UIAlertController(title: "title", message: msg, preferredStyle: .alert)
        let action = UIAlertAction(title: "ok", style: .cancel, handler: nil)
        alert.addAction(action)
        return alert;
    }
    
    private func createCustomPage()->UIViewController{
        let sb = UIStoryboard(name: "MyStoryboard", bundle: nil)
        return sb.instantiateViewController(withIdentifier: "MyStoryboard")
    }

}
