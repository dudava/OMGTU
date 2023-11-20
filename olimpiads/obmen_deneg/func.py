def happy(unhappy_nums, num):
    c = 0
    for _ in range(len(unhappy_nums)):
        if num >= unhappy_nums[_]:
            c += 1
        else:
            break
    return c 


def to_happy(unhappy_nums, num):
    c = 0
    for _ in range(len(unhappy_nums)):
        if num >= unhappy_nums[_]:
            num += 1
            c += 1
        else:
            break
    return c 
    

def p(ks):
    product = 1
    for k in ks:
        product *= k
    return product


def func(C_start, start_unhappy, C_end, end_unhappy, start_amount):
    summ = 0
    for _ in range(len(start_amount)):
        num = start_amount[_]
        summ += (num - happy(start_unhappy, num)) * p(C_start[:len(C_start) - _])
    
    result = []
    os = 0
    for _ in range(len(C_end)):
        os = summ // p(C_end[:len(C_end) - _])
        summ -= os * p(C_end[:len(C_end) - _])
        result.append(os + to_happy(end_unhappy, os))
    result.append(summ + to_happy(end_unhappy, summ))
    return " ".join([str(_) for _ in result])
