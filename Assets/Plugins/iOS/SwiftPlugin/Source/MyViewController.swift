//
//  MyViewController.swift
//  Test
//
//  Created by Mark on 2019/1/21.
//  Copyright © 2019 Mark. All rights reserved.
//

import UIKit

class MyViewController: UIViewController {

    @IBOutlet var btnReturn:UIButton!
    
    override func viewDidLoad() {
        super.viewDidLoad()
    }
    
    @IBAction func doReturn(){                
        self.dismiss(animated: true) {
            UnityPostMessage("NATIVE_BRIDGE", "NativeReceiveMsg", "hihi I'm swift")
        }
    }    
    
}
