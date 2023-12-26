def func(a, b, c, s1, s2, s3, m1, m2, m3):
    def dot_vector(a, b):
        vector = []
        for i in range(0, 3):
            vector.append(b[i]-a[i])
        return vector


    def vector_length(vector):
        length = 0
        for i in vector:
            length += i**2
        return length**(1/2)


    #муха слева
    if (m1 == 0):
        if (s1 == 0):
            dist = vector_length(dot_vector([m1, m2, m3], [s1, s2, s3]))
        if s3 == c:
            dist = vector_length(dot_vector([m2, m3, 0], [s2, c + s1, 0]))
        if s3 == 0:
            dist = vector_length(dot_vector([m2, m3, 0], [s2, -s1, 0]))
        if s2 == 0:
            dist = vector_length(dot_vector([-m2, m3, 0], [s1, s3, 0]))
        if s2 == b:
            dist = vector_length(dot_vector([m2, m3, 0], [b + s1, s3, 0]))
        if s1 == a:
            dist = min(vector_length(dot_vector([-m2, m3, 0], [a + s1, s3, 0])),
                    vector_length(dot_vector([m2, m3, 0], [s2, c - s3 + c + a, 0])),
                    vector_length(dot_vector([m2, m3, 0], [s2, -(a + s3), 0])),
                    vector_length(dot_vector([m2, m3, 0], [b + a + b - s2, s3, 0])))
    #муха вблизи
    if m2 == 0:
        if (s2 == 0):
            dist = vector_length(dot_vector([m1, m2, m3], [s1, s2, s3]))
        if (s1 == 0):
            dist = vector_length(dot_vector([m1, m3, 0], [-s2, s3, 0]))
        if (s3 == 0):
            dist = vector_length(dot_vector([m1, m3, 0], [s1, -s2, 0]))
        if (s3 == c):
            dist = vector_length(dot_vector([m1, m3, 0], [s1, c + s2, 0]))
        if (s1 == a):
            dist = vector_length(dot_vector([m1, m3, 0], [a + s2, s3, 0]))
        if s2 == b:
            dist = min(vector_length(dot_vector([m1, m3, 0], [s1, c + b + c - s3, 0])),
                    vector_length(dot_vector([m1, m3, 0], [a + b + a - s1, s3, 0])),
                    vector_length(dot_vector([m1, m3, 0], [-(b + s1), s3, 0])),
                    vector_length(dot_vector([m1, m3, 0], [s1, -(b + s3), 0])))
    #муха снизу
    if m3 == 0:
        if (s3 == 0):
            dist = vector_length(dot_vector([m1, m2, m3], [s1, s2, s3]))
        if (s1 == 0):
            dist = vector_length(dot_vector([m2, -m1, 0], [s2, s3, 0]))
        if (s2 == 0):
            dist = vector_length(dot_vector([m1, -m2, 0], [s1, s3, 0]))
        if (s1 == a):
            dist = vector_length(dot_vector([m2, m1, 0], [s2, a + s3, 0]))
        if (s2 == b):
            dist = vector_length(dot_vector([m1, m2, 0], [s1, b + s3, 0]))
        if s3 == c:
            dist = min(vector_length(dot_vector([m1, -m2, 0], [s1, c + s2, 0])),
                    vector_length(dot_vector([m2, -m1, 0], [s2, c + s1, 0])),
                    vector_length(dot_vector([m1, m2, 0], [s1, b + c + b - s2, 0])),
                    vector_length(dot_vector([m2, m1, 0], [s2, a + c + a - s1, 0])))
    #муха сверху
    if m3 == c:
        if (s3 == c): #верхняя
            dist = vector_length(dot_vector([m1, m2, m3], [s1, s2, s3]))
        if (s1 == 0): #левая
            dist = vector_length(dot_vector([m2, c + m1, 0], [s2, s3, 0]))
        if (s2 == 0): #ближняя
            dist = vector_length(dot_vector([m1, c + m2, 0], [s1, s3, 0]))
        if (s2 == b): #дальняя
            dist = vector_length(dot_vector([m1, c + m2, 0], [s1, c + b + c - s3, 0]))
        if (s1 == a): #правая
            dist = vector_length(dot_vector([m2, c + m1, 0], [s2, c + a + c - s3, 0]))
        if (s3 == 0): #нижняя
            dist = min(vector_length(dot_vector([m2, c + m1, 0], [s2, -s1, 0])),
                    vector_length(dot_vector([m1, c + m2, 0], [s1, -s2, 0])),
                    vector_length(dot_vector([m2, c + m1, 0], [s2, c + a + c + a - s1, 0])),
                    vector_length(dot_vector([m1, c + m2, 0], [s1, c + b + c + b - s2, 0])))
    #муха вдали
    if m2 == b:
        if (s2 == b): #дальняя
            dist = vector_length(dot_vector([m1, m2, m3], [s1, s2, s3]))
        if (s1 == 0): #левая
            dist = vector_length(dot_vector([b + m1, m3, 0], [s2, s3, 0]))
        if (s3 == 0): #нижняя
            dist = vector_length(dot_vector([b + m1, m3, 0], [s2, -s1, 0]))
        if (s3 == c): #верхняя
            dist = vector_length(dot_vector([b + m1, m3, 0], [s2, c + s1, 0]))
        if (s1 == a): #правая
            dist = vector_length(dot_vector([b + m1, m3, 0], [b + a + b - s2, s3, 0]))
        if (s2 == 0): #ближняя
            dist = min(vector_length(dot_vector([m1, c + b + c - m3, 0], [s1, s3, 0])),
                    vector_length(dot_vector([a + b + a - m1, m3, 0], [s1, s3, 0])),
                    vector_length(dot_vector([m1, -(b + m3), 0], [s1, s3, 0])),
                    vector_length(dot_vector([-(b + m1), m3, 0], [s1, s3, 0])))
    #муха справа
    if m1 == a:
        if (s1 == a): #правая
            dist = vector_length(dot_vector([m1, m2, m3], [s1, s2, s3]))
        if (s2 == 0): #ближняя
            dist = vector_length(dot_vector([a + m2, m3, 0], [s1, s3, 0]))
            return format(round(dist, 3), ".3f")
        if (s3 == 0): #нижняя
            dist = vector_length(dot_vector([m2, a + m3, 0], [s2, s1, 0]))
        if (s3 == c): #верхняя
            dist = vector_length(dot_vector([m2, c + a + c - m3, 0], [s2, c + s1, 0]))
        if (s2 == b): #дальняя
            dist = vector_length(dot_vector([b + a + b - m2, m3, 0], [b + s1, s3, 0]))
        if (s1 == 0): #левая
            dist = min(vector_length(dot_vector([m2, c + a + c - m3, 0], [s2, s3, 0])),
                    vector_length(dot_vector([a + m2, m3, 0], [-s2, s3, 0])),
                    vector_length(dot_vector([m2, -(a + m3), 0], [s2, s3, 0])),
                    vector_length(dot_vector([b + a + b - m2, m3, 0], [s2, s3, 0])))

    out = format(round(dist, 3), ".3f")
    if dist == 0:
        out = "0.000"
    return out