using System;
class HelloWorld {
    static void neighborhood() {
      int count;
      int prev = 0, cur = 0, next = 0;
      
      count = Convert.ToInt32(Console.ReadLine());
      int counter = 0;
      for (int i=0; i < count; i++) {
          int num = Convert.ToInt32(Console.ReadLine());
          
          if (i == 0) {
              prev = num;
          }
          else if (i == 1) {
              cur = num;
          }
          else if (i > 1) {
              next = num;
          }
          if (cur < prev && cur < next) {
              counter++;
          }
          prev = cur;
          cur = next;
      }
      Console.WriteLine(counter);  
    }
    static void plus_minus() {
        int count = Convert.ToInt32(Console.ReadLine());
        int counter = 0;
        bool is_minus = false;
        
        for (int i = 0; i < count; i++) {
            int num = Convert.ToInt32(Console.ReadLine());
            if (i > 0) {
                if (num < 0 & is_minus == false) {
                    counter++;
                }
                if (num >= 0 & is_minus == true) {
                    counter++;
                    is_minus = false;
                }    
            }
            
            if (num < 0) {
                is_minus = true;
            }
            else {
                is_minus = false;
            }
        }
        Console.WriteLine(counter);
    }
    static void max_length_equal_elements() {
        int count = Convert.ToInt32(Console.ReadLine());
        int max_length = 0;
        int max_cur_length = 0;
        int prev_num = 0;
        
        for (int i = 0; i < count; i++) {
            int num = Convert.ToInt32(Console.ReadLine());
            if (i == 0) {
                prev_num = num;
            }
            if (prev_num == num) {
                max_cur_length++;    
            }
            else {
                if (max_cur_length > max_length) {
                    max_length = max_cur_length;
                }
                max_cur_length = 0;
            }
            prev_num = num;
        }
        Console.WriteLine(max_length);
    }
    static void tilt(){
        int count = Convert.ToInt32(Console.ReadLine());
        int min_len = 99999999;
        int cur_len = 0;
        int prev_num = 0;
        
        for (int i = 0; i < count; i++) {
            int num = Convert.ToInt32(Console.ReadLine());
            if (i == 0) {
                prev_num = num;
            }
            if (num < 0) {
                cur_len++;
            }
            else {
                if (cur_len < min_len) {
                    min_len = cur_len;
                }
                cur_len = 0;
            }
            if (i == count - 1 && cur_len != 0) {
                if (cur_len < min_len) {
                    min_len = cur_len;
                }
            }
            prev_num = num;
        }
        Console.WriteLine(min_len);
    }
  static void Main() {
    //   neighborhood();
    // plus_minus();
    //max_length_equal_elements();
    tilt();
  }
}