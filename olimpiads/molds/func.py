def func(n, default_details, default_forms):
    details = []
    for i in range(0, n):
        a = default_details[i]
        details.append([a[0:5] , a[5:10], a[10:15], a[15:20]])

    forms = []
    for i in range(0, n*2):
        a = default_forms[i]
        forms.append([a[0:5] , a[5:10], a[10:15]])


    def match(form1, form2, detail):
        if (detail[0] == form1[0] == form2[2]):
            if (detail[1] == form2[1]):
                if (detail[2] == form2[0] == form1[2]):
                    if (detail[3] == form1[1]):
                        return True

        if (detail[0] == form1[0] == form2[0][::-1]):
            if (detail[1] == form2[1][::-1]):
                if (detail[2] == form2[2][::-1] == form1[2]):
                    if (detail[3] == form1[1]):
                        return True
        return False


    def rotate(detail):
        return [detail[3], detail[0], detail[1], detail[2]]


    def turn_over(detail):
        return [detail[0][::-1], detail[3][::-1], detail[2][::-1], detail[1][::-1]]


    pairs = []
    for d_i in range(0, len(details)):
        d = details[d_i]
        for r in range(0, 5):
            for f1_i in range(0, len(forms)):
                for f2_i in range(0, len(forms)):
                    if f2_i != f1_i:
                        if match(forms[f1_i], forms[f2_i], d):
                            pairs.append([f1_i, f2_i])
            if r == 2:
                d = rotate(d)
                d = turn_over(d)
            else:
                d = rotate(d)

    index_m = [3]
    while True:
        index_m = []
        for p in pairs:
            index = 0
            for ap in pairs:
                if p[0] in ap:
                    index += 1
                if p[1] in ap:
                    index += 1
            index_m.append(index)
        if max(index_m) == 2:
            break
        pairs.pop(index_m.index(max(index_m)))

    pairs = [tuple([i + 1 for i in sorted(_)]) for _ in pairs]
    return pairs