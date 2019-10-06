\ENCODING=ISO-8859-1
\Problem name: ILOG.CPLEX

Minimize
 obj: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8 + crew_6_10
      + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22 + crew_15_24
      + crew_16_26 + crew_17_28 + crew_18_30 + crew_19_32 + crew_20_34
      + crew_21_36 + crew_22_38 + crew_1_48 + crew_2_50 + crew_3_52 + crew_4_54
      + crew_5_56 + crew_6_58 + crew_11_64 + crew_12_66 + crew_13_68
      + crew_14_70 + crew_15_72 + crew_16_74 + crew_17_76 + crew_18_78
      + crew_19_80 + crew_20_82 + crew_21_84 + crew_22_86 + crew_1_96
      + crew_2_98 + crew_3_100 + crew_4_102 + crew_5_104 + crew_6_106
      + crew_11_112 + crew_12_114 + crew_13_116 + crew_14_118 + crew_15_120
      + crew_16_122 + crew_17_124 + crew_18_126 + crew_19_128 + crew_20_130
      + crew_21_132 + crew_22_134 + crew_23_136 + crew_24_138 + crew_25_140
      + crew_26_142 + crew_27_144 + crew_28_146 + crew_1_160 + crew_2_162
      + crew_3_164 + crew_6_168 + crew_7_170 + crew_8_172 + crew_9_174
      + crew_10_176 + crew_11_178 + crew_12_180 + crew_13_182 + crew_14_184
      + crew_15_186 + crew_16_188 + crew_17_190 + crew_18_192 + crew_19_194
      + crew_20_196 + crew_1_208 + crew_2_210 + crew_3_212 + crew_6_216
      + crew_7_218 + crew_8_220 + crew_9_222 + crew_10_224 + crew_11_226
      + crew_12_228 + crew_13_230 + crew_14_232 + crew_15_234 + crew_16_236
      + crew_17_238 + crew_18_240 + crew_19_242 + crew_20_244 + crew_1_286
      + crew_2_288 + crew_3_290 + crew_4_292 + crew_5_294 + crew_6_296
      + crew_11_302 + crew_12_304 + crew_13_306 + crew_14_308 + crew_15_310
      + crew_16_312 + crew_17_314 + crew_18_316 + crew_19_318 + crew_20_320
      + crew_21_322 + crew_22_324
Subject To
 day_0_route_1: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_9_14
                + crew_10_15 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_27_44 + crew_28_45 + crew_29_46
                + crew_30_47 >= 1
 day_0_route_2: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_9_14
                + crew_10_15 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_27_44 + crew_28_45 + crew_29_46
                + crew_30_47 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_9_62 + crew_10_63 + crew_11_64 + crew_11_65 + crew_12_66
                + crew_12_67 + crew_13_68 + crew_13_69 + crew_14_70
                + crew_14_71 + crew_27_92 + crew_28_93 + crew_29_94
                + crew_30_95 >= 1
 day_0_route_3: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_9_14
                + crew_10_15 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_27_44 + crew_28_45 + crew_29_46
                + crew_30_47 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_9_62 + crew_10_63 + crew_11_64 + crew_11_65 + crew_12_66
                + crew_12_67 + crew_13_68 + crew_13_69 + crew_14_70
                + crew_14_71 + crew_27_92 + crew_28_93 + crew_29_94
                + crew_30_95 + crew_1_96 + crew_1_97 + crew_2_98 + crew_2_99
                + crew_9_110 + crew_10_111 + crew_11_112 + crew_11_113
                + crew_12_114 + crew_12_115 + crew_13_116 + crew_13_117
                + crew_14_118 + crew_14_119 + crew_15_120 + crew_15_121
                + crew_16_122 + crew_16_123 + crew_35_154 + crew_36_155
                + crew_37_156 + crew_38_157 + crew_39_158 + crew_40_159 >= 1
 day_0_route_4: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_9_14
                + crew_10_15 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_27_44 + crew_28_45 + crew_29_46
                + crew_30_47 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_9_62 + crew_10_63 + crew_11_64 + crew_11_65 + crew_12_66
                + crew_12_67 + crew_13_68 + crew_13_69 + crew_14_70
                + crew_14_71 + crew_27_92 + crew_28_93 + crew_29_94
                + crew_30_95 + crew_1_96 + crew_1_97 + crew_2_98 + crew_2_99
                + crew_9_110 + crew_10_111 + crew_11_112 + crew_11_113
                + crew_12_114 + crew_12_115 + crew_13_116 + crew_13_117
                + crew_14_118 + crew_14_119 + crew_15_120 + crew_15_121
                + crew_16_122 + crew_16_123 + crew_35_154 + crew_36_155
                + crew_37_156 + crew_38_157 + crew_39_158 + crew_40_159
                + crew_1_160 + crew_1_161 + crew_5_167 + crew_6_168
                + crew_6_169 + crew_7_170 + crew_7_171 + crew_8_172
                + crew_8_173 + crew_9_174 + crew_9_175 + crew_10_176
                + crew_10_177 + crew_26_203 + crew_27_204 + crew_28_205
                + crew_29_206 + crew_30_207 >= 1
 day_0_route_5: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_9_14
                + crew_10_15 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_27_44 + crew_28_45 + crew_29_46
                + crew_30_47 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_9_62 + crew_10_63 + crew_11_64 + crew_11_65 + crew_12_66
                + crew_12_67 + crew_13_68 + crew_13_69 + crew_14_70
                + crew_14_71 + crew_27_92 + crew_28_93 + crew_29_94
                + crew_30_95 + crew_1_96 + crew_1_97 + crew_2_98 + crew_2_99
                + crew_9_110 + crew_10_111 + crew_11_112 + crew_11_113
                + crew_12_114 + crew_12_115 + crew_13_116 + crew_13_117
                + crew_14_118 + crew_14_119 + crew_15_120 + crew_15_121
                + crew_16_122 + crew_16_123 + crew_35_154 + crew_36_155
                + crew_37_156 + crew_38_157 + crew_39_158 + crew_40_159
                + crew_1_160 + crew_1_161 + crew_5_167 + crew_6_168
                + crew_6_169 + crew_7_170 + crew_7_171 + crew_8_172
                + crew_8_173 + crew_9_174 + crew_9_175 + crew_10_176
                + crew_10_177 + crew_26_203 + crew_27_204 + crew_28_205
                + crew_29_206 + crew_30_207 + crew_1_208 + crew_1_209
                + crew_5_215 + crew_6_216 + crew_6_217 + crew_7_218
                + crew_7_219 + crew_8_220 + crew_8_221 + crew_9_222
                + crew_9_223 + crew_10_224 + crew_10_225 + crew_26_251
                + crew_27_252 + crew_28_253 + crew_29_254 + crew_30_255 >= 1
 day_0_route_6: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_9_14
                + crew_10_15 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_27_44 + crew_28_45 + crew_29_46
                + crew_30_47 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_9_62 + crew_10_63 + crew_11_64 + crew_11_65 + crew_12_66
                + crew_12_67 + crew_13_68 + crew_13_69 + crew_14_70
                + crew_14_71 + crew_27_92 + crew_28_93 + crew_29_94
                + crew_30_95 + crew_1_96 + crew_1_97 + crew_2_98 + crew_2_99
                + crew_9_110 + crew_10_111 + crew_11_112 + crew_11_113
                + crew_12_114 + crew_12_115 + crew_13_116 + crew_13_117
                + crew_14_118 + crew_14_119 + crew_15_120 + crew_15_121
                + crew_16_122 + crew_16_123 + crew_35_154 + crew_36_155
                + crew_37_156 + crew_38_157 + crew_39_158 + crew_40_159
                + crew_1_160 + crew_1_161 + crew_5_167 + crew_6_168
                + crew_6_169 + crew_7_170 + crew_7_171 + crew_8_172
                + crew_8_173 + crew_9_174 + crew_9_175 + crew_10_176
                + crew_10_177 + crew_26_203 + crew_27_204 + crew_28_205
                + crew_29_206 + crew_30_207 + crew_1_208 + crew_1_209
                + crew_5_215 + crew_6_216 + crew_6_217 + crew_7_218
                + crew_7_219 + crew_8_220 + crew_8_221 + crew_9_222
                + crew_9_223 + crew_10_224 + crew_10_225 + crew_26_251
                + crew_27_252 + crew_28_253 + crew_29_254 + crew_30_255
                + crew_1_256 + crew_2_257 + crew_9_264 + crew_10_265
                + crew_11_266 + crew_12_267 + crew_13_268 + crew_14_269
                + crew_27_282 + crew_28_283 + crew_29_284 + crew_30_285 >= 1
 day_0_route_7: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_9_14
                + crew_10_15 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_27_44 + crew_28_45 + crew_29_46
                + crew_30_47 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_9_62 + crew_10_63 + crew_11_64 + crew_11_65 + crew_12_66
                + crew_12_67 + crew_13_68 + crew_13_69 + crew_14_70
                + crew_14_71 + crew_27_92 + crew_28_93 + crew_29_94
                + crew_30_95 + crew_1_96 + crew_1_97 + crew_2_98 + crew_2_99
                + crew_9_110 + crew_10_111 + crew_11_112 + crew_11_113
                + crew_12_114 + crew_12_115 + crew_13_116 + crew_13_117
                + crew_14_118 + crew_14_119 + crew_15_120 + crew_15_121
                + crew_16_122 + crew_16_123 + crew_35_154 + crew_36_155
                + crew_37_156 + crew_38_157 + crew_39_158 + crew_40_159
                + crew_1_160 + crew_1_161 + crew_5_167 + crew_6_168
                + crew_6_169 + crew_7_170 + crew_7_171 + crew_8_172
                + crew_8_173 + crew_9_174 + crew_9_175 + crew_10_176
                + crew_10_177 + crew_26_203 + crew_27_204 + crew_28_205
                + crew_29_206 + crew_30_207 + crew_1_208 + crew_1_209
                + crew_5_215 + crew_6_216 + crew_6_217 + crew_7_218
                + crew_7_219 + crew_8_220 + crew_8_221 + crew_9_222
                + crew_9_223 + crew_10_224 + crew_10_225 + crew_26_251
                + crew_27_252 + crew_28_253 + crew_29_254 + crew_30_255
                + crew_1_256 + crew_2_257 + crew_9_264 + crew_10_265
                + crew_11_266 + crew_12_267 + crew_13_268 + crew_14_269
                + crew_27_282 + crew_28_283 + crew_29_284 + crew_30_285
                + crew_1_286 + crew_1_287 + crew_2_288 + crew_2_289
                + crew_9_300 + crew_10_301 + crew_11_302 + crew_11_303
                + crew_12_304 + crew_12_305 + crew_13_306 + crew_13_307
                + crew_14_308 + crew_14_309 + crew_27_330 + crew_28_331
                + crew_29_332 + crew_30_333 >= 1
 day_1_route_1: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_3_4 + crew_3_5
                + crew_4_6 + crew_4_7 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 >= 1
 day_1_route_2: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_3_4 + crew_3_5
                + crew_4_6 + crew_4_7 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55 + crew_11_64
                + crew_11_65 + crew_12_66 + crew_12_67 + crew_13_68
                + crew_13_69 + crew_14_70 + crew_14_71 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 >= 1
 day_1_route_3: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_3_4 + crew_3_5
                + crew_4_6 + crew_4_7 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55 + crew_11_64
                + crew_11_65 + crew_12_66 + crew_12_67 + crew_13_68
                + crew_13_69 + crew_14_70 + crew_14_71 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_1_96 + crew_1_97
                + crew_2_98 + crew_2_99 + crew_3_100 + crew_3_101 + crew_4_102
                + crew_4_103 + crew_11_112 + crew_11_113 + crew_12_114
                + crew_12_115 + crew_13_116 + crew_13_117 + crew_14_118
                + crew_14_119 + crew_15_120 + crew_15_121 + crew_16_122
                + crew_16_123 + crew_17_124 + crew_17_125 + crew_18_126
                + crew_18_127 + crew_19_128 + crew_19_129 + crew_20_130
                + crew_20_131 + crew_21_132 + crew_21_133 + crew_22_134
                + crew_22_135 >= 1
 day_1_route_4: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_3_4 + crew_3_5
                + crew_4_6 + crew_4_7 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55 + crew_11_64
                + crew_11_65 + crew_12_66 + crew_12_67 + crew_13_68
                + crew_13_69 + crew_14_70 + crew_14_71 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_1_96 + crew_1_97
                + crew_2_98 + crew_2_99 + crew_3_100 + crew_3_101 + crew_4_102
                + crew_4_103 + crew_11_112 + crew_11_113 + crew_12_114
                + crew_12_115 + crew_13_116 + crew_13_117 + crew_14_118
                + crew_14_119 + crew_15_120 + crew_15_121 + crew_16_122
                + crew_16_123 + crew_17_124 + crew_17_125 + crew_18_126
                + crew_18_127 + crew_19_128 + crew_19_129 + crew_20_130
                + crew_20_131 + crew_21_132 + crew_21_133 + crew_22_134
                + crew_22_135 + crew_1_160 + crew_1_161 + crew_2_162
                + crew_2_163 + crew_6_168 + crew_6_169 + crew_7_170
                + crew_7_171 + crew_8_172 + crew_8_173 + crew_9_174
                + crew_9_175 + crew_10_176 + crew_10_177 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 >= 1
 day_1_route_5: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_3_4 + crew_3_5
                + crew_4_6 + crew_4_7 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55 + crew_11_64
                + crew_11_65 + crew_12_66 + crew_12_67 + crew_13_68
                + crew_13_69 + crew_14_70 + crew_14_71 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_1_96 + crew_1_97
                + crew_2_98 + crew_2_99 + crew_3_100 + crew_3_101 + crew_4_102
                + crew_4_103 + crew_11_112 + crew_11_113 + crew_12_114
                + crew_12_115 + crew_13_116 + crew_13_117 + crew_14_118
                + crew_14_119 + crew_15_120 + crew_15_121 + crew_16_122
                + crew_16_123 + crew_17_124 + crew_17_125 + crew_18_126
                + crew_18_127 + crew_19_128 + crew_19_129 + crew_20_130
                + crew_20_131 + crew_21_132 + crew_21_133 + crew_22_134
                + crew_22_135 + crew_1_160 + crew_1_161 + crew_2_162
                + crew_2_163 + crew_6_168 + crew_6_169 + crew_7_170
                + crew_7_171 + crew_8_172 + crew_8_173 + crew_9_174
                + crew_9_175 + crew_10_176 + crew_10_177 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 + crew_1_208 + crew_1_209 + crew_2_210
                + crew_2_211 + crew_6_216 + crew_6_217 + crew_7_218
                + crew_7_219 + crew_8_220 + crew_8_221 + crew_9_222
                + crew_9_223 + crew_10_224 + crew_10_225 + crew_11_226
                + crew_11_227 + crew_12_228 + crew_12_229 + crew_13_230
                + crew_13_231 + crew_14_232 + crew_14_233 + crew_15_234
                + crew_15_235 >= 1
 day_1_route_6: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_3_4 + crew_3_5
                + crew_4_6 + crew_4_7 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55 + crew_11_64
                + crew_11_65 + crew_12_66 + crew_12_67 + crew_13_68
                + crew_13_69 + crew_14_70 + crew_14_71 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_1_96 + crew_1_97
                + crew_2_98 + crew_2_99 + crew_3_100 + crew_3_101 + crew_4_102
                + crew_4_103 + crew_11_112 + crew_11_113 + crew_12_114
                + crew_12_115 + crew_13_116 + crew_13_117 + crew_14_118
                + crew_14_119 + crew_15_120 + crew_15_121 + crew_16_122
                + crew_16_123 + crew_17_124 + crew_17_125 + crew_18_126
                + crew_18_127 + crew_19_128 + crew_19_129 + crew_20_130
                + crew_20_131 + crew_21_132 + crew_21_133 + crew_22_134
                + crew_22_135 + crew_1_160 + crew_1_161 + crew_2_162
                + crew_2_163 + crew_6_168 + crew_6_169 + crew_7_170
                + crew_7_171 + crew_8_172 + crew_8_173 + crew_9_174
                + crew_9_175 + crew_10_176 + crew_10_177 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 + crew_1_208 + crew_1_209 + crew_2_210
                + crew_2_211 + crew_6_216 + crew_6_217 + crew_7_218
                + crew_7_219 + crew_8_220 + crew_8_221 + crew_9_222
                + crew_9_223 + crew_10_224 + crew_10_225 + crew_11_226
                + crew_11_227 + crew_12_228 + crew_12_229 + crew_13_230
                + crew_13_231 + crew_14_232 + crew_14_233 + crew_15_234
                + crew_15_235 + crew_1_256 + crew_2_257 + crew_3_258
                + crew_4_259 + crew_11_266 + crew_12_267 + crew_13_268
                + crew_14_269 + crew_15_270 + crew_16_271 + crew_17_272
                + crew_18_273 >= 1
 day_1_route_7: crew_1_0 + crew_1_1 + crew_2_2 + crew_2_3 + crew_3_4 + crew_3_5
                + crew_4_6 + crew_4_7 + crew_11_16 + crew_11_17 + crew_12_18
                + crew_12_19 + crew_13_20 + crew_13_21 + crew_14_22
                + crew_14_23 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_1_48 + crew_1_49 + crew_2_50 + crew_2_51
                + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55 + crew_11_64
                + crew_11_65 + crew_12_66 + crew_12_67 + crew_13_68
                + crew_13_69 + crew_14_70 + crew_14_71 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_1_96 + crew_1_97
                + crew_2_98 + crew_2_99 + crew_3_100 + crew_3_101 + crew_4_102
                + crew_4_103 + crew_11_112 + crew_11_113 + crew_12_114
                + crew_12_115 + crew_13_116 + crew_13_117 + crew_14_118
                + crew_14_119 + crew_15_120 + crew_15_121 + crew_16_122
                + crew_16_123 + crew_17_124 + crew_17_125 + crew_18_126
                + crew_18_127 + crew_19_128 + crew_19_129 + crew_20_130
                + crew_20_131 + crew_21_132 + crew_21_133 + crew_22_134
                + crew_22_135 + crew_1_160 + crew_1_161 + crew_2_162
                + crew_2_163 + crew_6_168 + crew_6_169 + crew_7_170
                + crew_7_171 + crew_8_172 + crew_8_173 + crew_9_174
                + crew_9_175 + crew_10_176 + crew_10_177 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 + crew_1_208 + crew_1_209 + crew_2_210
                + crew_2_211 + crew_6_216 + crew_6_217 + crew_7_218
                + crew_7_219 + crew_8_220 + crew_8_221 + crew_9_222
                + crew_9_223 + crew_10_224 + crew_10_225 + crew_11_226
                + crew_11_227 + crew_12_228 + crew_12_229 + crew_13_230
                + crew_13_231 + crew_14_232 + crew_14_233 + crew_15_234
                + crew_15_235 + crew_1_256 + crew_2_257 + crew_3_258
                + crew_4_259 + crew_11_266 + crew_12_267 + crew_13_268
                + crew_14_269 + crew_15_270 + crew_16_271 + crew_17_272
                + crew_18_273 + crew_1_286 + crew_1_287 + crew_2_288
                + crew_2_289 + crew_3_290 + crew_3_291 + crew_4_292
                + crew_4_293 + crew_11_302 + crew_11_303 + crew_12_304
                + crew_12_305 + crew_13_306 + crew_13_307 + crew_14_308
                + crew_14_309 + crew_15_310 + crew_15_311 + crew_16_312
                + crew_16_313 + crew_17_314 + crew_17_315 + crew_18_316
                + crew_18_317 >= 1
 day_2_route_1: crew_3_4 + crew_3_5 + crew_4_6 + crew_4_7 + crew_5_8 + crew_5_9
                + crew_6_10 + crew_6_11 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_19_32 + crew_19_33 + crew_20_34
                + crew_20_35 + crew_21_36 + crew_21_37 + crew_22_38
                + crew_22_39 >= 1
 day_2_route_2: crew_3_4 + crew_3_5 + crew_4_6 + crew_4_7 + crew_5_8 + crew_5_9
                + crew_6_10 + crew_6_11 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_19_32 + crew_19_33 + crew_20_34
                + crew_20_35 + crew_21_36 + crew_21_37 + crew_22_38
                + crew_22_39 + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55
                + crew_5_56 + crew_5_57 + crew_6_58 + crew_6_59 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_19_80
                + crew_19_81 + crew_20_82 + crew_20_83 + crew_21_84
                + crew_21_85 + crew_22_86 + crew_22_87 >= 1
 day_2_route_3: crew_3_4 + crew_3_5 + crew_4_6 + crew_4_7 + crew_5_8 + crew_5_9
                + crew_6_10 + crew_6_11 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_19_32 + crew_19_33 + crew_20_34
                + crew_20_35 + crew_21_36 + crew_21_37 + crew_22_38
                + crew_22_39 + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55
                + crew_5_56 + crew_5_57 + crew_6_58 + crew_6_59 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_19_80
                + crew_19_81 + crew_20_82 + crew_20_83 + crew_21_84
                + crew_21_85 + crew_22_86 + crew_22_87 + crew_3_100
                + crew_3_101 + crew_4_102 + crew_4_103 + crew_5_104
                + crew_5_105 + crew_6_106 + crew_6_107 + crew_17_124
                + crew_17_125 + crew_18_126 + crew_18_127 + crew_19_128
                + crew_19_129 + crew_20_130 + crew_20_131 + crew_21_132
                + crew_21_133 + crew_22_134 + crew_22_135 + crew_23_136
                + crew_23_137 + crew_24_138 + crew_24_139 + crew_25_140
                + crew_25_141 + crew_26_142 + crew_26_143 + crew_27_144
                + crew_27_145 + crew_28_146 + crew_28_147 >= 1
 day_2_route_4: crew_3_4 + crew_3_5 + crew_4_6 + crew_4_7 + crew_5_8 + crew_5_9
                + crew_6_10 + crew_6_11 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_19_32 + crew_19_33 + crew_20_34
                + crew_20_35 + crew_21_36 + crew_21_37 + crew_22_38
                + crew_22_39 + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55
                + crew_5_56 + crew_5_57 + crew_6_58 + crew_6_59 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_19_80
                + crew_19_81 + crew_20_82 + crew_20_83 + crew_21_84
                + crew_21_85 + crew_22_86 + crew_22_87 + crew_3_100
                + crew_3_101 + crew_4_102 + crew_4_103 + crew_5_104
                + crew_5_105 + crew_6_106 + crew_6_107 + crew_17_124
                + crew_17_125 + crew_18_126 + crew_18_127 + crew_19_128
                + crew_19_129 + crew_20_130 + crew_20_131 + crew_21_132
                + crew_21_133 + crew_22_134 + crew_22_135 + crew_23_136
                + crew_23_137 + crew_24_138 + crew_24_139 + crew_25_140
                + crew_25_141 + crew_26_142 + crew_26_143 + crew_27_144
                + crew_27_145 + crew_28_146 + crew_28_147 + crew_2_162
                + crew_2_163 + crew_3_164 + crew_3_165 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 + crew_16_188 + crew_16_189 + crew_17_190
                + crew_17_191 + crew_18_192 + crew_18_193 + crew_19_194
                + crew_19_195 + crew_20_196 + crew_20_197 >= 1
 day_2_route_5: crew_3_4 + crew_3_5 + crew_4_6 + crew_4_7 + crew_5_8 + crew_5_9
                + crew_6_10 + crew_6_11 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_19_32 + crew_19_33 + crew_20_34
                + crew_20_35 + crew_21_36 + crew_21_37 + crew_22_38
                + crew_22_39 + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55
                + crew_5_56 + crew_5_57 + crew_6_58 + crew_6_59 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_19_80
                + crew_19_81 + crew_20_82 + crew_20_83 + crew_21_84
                + crew_21_85 + crew_22_86 + crew_22_87 + crew_3_100
                + crew_3_101 + crew_4_102 + crew_4_103 + crew_5_104
                + crew_5_105 + crew_6_106 + crew_6_107 + crew_17_124
                + crew_17_125 + crew_18_126 + crew_18_127 + crew_19_128
                + crew_19_129 + crew_20_130 + crew_20_131 + crew_21_132
                + crew_21_133 + crew_22_134 + crew_22_135 + crew_23_136
                + crew_23_137 + crew_24_138 + crew_24_139 + crew_25_140
                + crew_25_141 + crew_26_142 + crew_26_143 + crew_27_144
                + crew_27_145 + crew_28_146 + crew_28_147 + crew_2_162
                + crew_2_163 + crew_3_164 + crew_3_165 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 + crew_16_188 + crew_16_189 + crew_17_190
                + crew_17_191 + crew_18_192 + crew_18_193 + crew_19_194
                + crew_19_195 + crew_20_196 + crew_20_197 + crew_2_210
                + crew_2_211 + crew_3_212 + crew_3_213 + crew_11_226
                + crew_11_227 + crew_12_228 + crew_12_229 + crew_13_230
                + crew_13_231 + crew_14_232 + crew_14_233 + crew_15_234
                + crew_15_235 + crew_16_236 + crew_16_237 + crew_17_238
                + crew_17_239 + crew_18_240 + crew_18_241 + crew_19_242
                + crew_19_243 + crew_20_244 + crew_20_245 >= 1
 day_2_route_6: crew_3_4 + crew_3_5 + crew_4_6 + crew_4_7 + crew_5_8 + crew_5_9
                + crew_6_10 + crew_6_11 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_19_32 + crew_19_33 + crew_20_34
                + crew_20_35 + crew_21_36 + crew_21_37 + crew_22_38
                + crew_22_39 + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55
                + crew_5_56 + crew_5_57 + crew_6_58 + crew_6_59 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_19_80
                + crew_19_81 + crew_20_82 + crew_20_83 + crew_21_84
                + crew_21_85 + crew_22_86 + crew_22_87 + crew_3_100
                + crew_3_101 + crew_4_102 + crew_4_103 + crew_5_104
                + crew_5_105 + crew_6_106 + crew_6_107 + crew_17_124
                + crew_17_125 + crew_18_126 + crew_18_127 + crew_19_128
                + crew_19_129 + crew_20_130 + crew_20_131 + crew_21_132
                + crew_21_133 + crew_22_134 + crew_22_135 + crew_23_136
                + crew_23_137 + crew_24_138 + crew_24_139 + crew_25_140
                + crew_25_141 + crew_26_142 + crew_26_143 + crew_27_144
                + crew_27_145 + crew_28_146 + crew_28_147 + crew_2_162
                + crew_2_163 + crew_3_164 + crew_3_165 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 + crew_16_188 + crew_16_189 + crew_17_190
                + crew_17_191 + crew_18_192 + crew_18_193 + crew_19_194
                + crew_19_195 + crew_20_196 + crew_20_197 + crew_2_210
                + crew_2_211 + crew_3_212 + crew_3_213 + crew_11_226
                + crew_11_227 + crew_12_228 + crew_12_229 + crew_13_230
                + crew_13_231 + crew_14_232 + crew_14_233 + crew_15_234
                + crew_15_235 + crew_16_236 + crew_16_237 + crew_17_238
                + crew_17_239 + crew_18_240 + crew_18_241 + crew_19_242
                + crew_19_243 + crew_20_244 + crew_20_245 + crew_3_258
                + crew_4_259 + crew_5_260 + crew_6_261 + crew_15_270
                + crew_16_271 + crew_17_272 + crew_18_273 + crew_19_274
                + crew_20_275 + crew_21_276 + crew_22_277 >= 1
 day_2_route_7: crew_3_4 + crew_3_5 + crew_4_6 + crew_4_7 + crew_5_8 + crew_5_9
                + crew_6_10 + crew_6_11 + crew_15_24 + crew_15_25 + crew_16_26
                + crew_16_27 + crew_17_28 + crew_17_29 + crew_18_30
                + crew_18_31 + crew_19_32 + crew_19_33 + crew_20_34
                + crew_20_35 + crew_21_36 + crew_21_37 + crew_22_38
                + crew_22_39 + crew_3_52 + crew_3_53 + crew_4_54 + crew_4_55
                + crew_5_56 + crew_5_57 + crew_6_58 + crew_6_59 + crew_15_72
                + crew_15_73 + crew_16_74 + crew_16_75 + crew_17_76
                + crew_17_77 + crew_18_78 + crew_18_79 + crew_19_80
                + crew_19_81 + crew_20_82 + crew_20_83 + crew_21_84
                + crew_21_85 + crew_22_86 + crew_22_87 + crew_3_100
                + crew_3_101 + crew_4_102 + crew_4_103 + crew_5_104
                + crew_5_105 + crew_6_106 + crew_6_107 + crew_17_124
                + crew_17_125 + crew_18_126 + crew_18_127 + crew_19_128
                + crew_19_129 + crew_20_130 + crew_20_131 + crew_21_132
                + crew_21_133 + crew_22_134 + crew_22_135 + crew_23_136
                + crew_23_137 + crew_24_138 + crew_24_139 + crew_25_140
                + crew_25_141 + crew_26_142 + crew_26_143 + crew_27_144
                + crew_27_145 + crew_28_146 + crew_28_147 + crew_2_162
                + crew_2_163 + crew_3_164 + crew_3_165 + crew_11_178
                + crew_11_179 + crew_12_180 + crew_12_181 + crew_13_182
                + crew_13_183 + crew_14_184 + crew_14_185 + crew_15_186
                + crew_15_187 + crew_16_188 + crew_16_189 + crew_17_190
                + crew_17_191 + crew_18_192 + crew_18_193 + crew_19_194
                + crew_19_195 + crew_20_196 + crew_20_197 + crew_2_210
                + crew_2_211 + crew_3_212 + crew_3_213 + crew_11_226
                + crew_11_227 + crew_12_228 + crew_12_229 + crew_13_230
                + crew_13_231 + crew_14_232 + crew_14_233 + crew_15_234
                + crew_15_235 + crew_16_236 + crew_16_237 + crew_17_238
                + crew_17_239 + crew_18_240 + crew_18_241 + crew_19_242
                + crew_19_243 + crew_20_244 + crew_20_245 + crew_3_258
                + crew_4_259 + crew_5_260 + crew_6_261 + crew_15_270
                + crew_16_271 + crew_17_272 + crew_18_273 + crew_19_274
                + crew_20_275 + crew_21_276 + crew_22_277 + crew_3_290
                + crew_3_291 + crew_4_292 + crew_4_293 + crew_5_294
                + crew_5_295 + crew_6_296 + crew_6_297 + crew_15_310
                + crew_15_311 + crew_16_312 + crew_16_313 + crew_17_314
                + crew_17_315 + crew_18_316 + crew_18_317 + crew_19_318
                + crew_19_319 + crew_20_320 + crew_20_321 + crew_21_322
                + crew_21_323 + crew_22_324 + crew_22_325 >= 1
 day_3_route_1: crew_5_8 + crew_5_9 + crew_6_10 + crew_6_11 + crew_7_12
                + crew_8_13 + crew_19_32 + crew_19_33 + crew_20_34 + crew_20_35
                + crew_21_36 + crew_21_37 + crew_22_38 + crew_22_39
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43 >= 1
 day_3_route_2: crew_5_8 + crew_5_9 + crew_6_10 + crew_6_11 + crew_7_12
                + crew_8_13 + crew_19_32 + crew_19_33 + crew_20_34 + crew_20_35
                + crew_21_36 + crew_21_37 + crew_22_38 + crew_22_39
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43 + crew_5_56
                + crew_5_57 + crew_6_58 + crew_6_59 + crew_7_60 + crew_8_61
                + crew_19_80 + crew_19_81 + crew_20_82 + crew_20_83
                + crew_21_84 + crew_21_85 + crew_22_86 + crew_22_87
                + crew_23_88 + crew_24_89 + crew_25_90 + crew_26_91 >= 1
 day_3_route_3: crew_5_8 + crew_5_9 + crew_6_10 + crew_6_11 + crew_7_12
                + crew_8_13 + crew_19_32 + crew_19_33 + crew_20_34 + crew_20_35
                + crew_21_36 + crew_21_37 + crew_22_38 + crew_22_39
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43 + crew_5_56
                + crew_5_57 + crew_6_58 + crew_6_59 + crew_7_60 + crew_8_61
                + crew_19_80 + crew_19_81 + crew_20_82 + crew_20_83
                + crew_21_84 + crew_21_85 + crew_22_86 + crew_22_87
                + crew_23_88 + crew_24_89 + crew_25_90 + crew_26_91
                + crew_5_104 + crew_5_105 + crew_6_106 + crew_6_107
                + crew_7_108 + crew_8_109 + crew_23_136 + crew_23_137
                + crew_24_138 + crew_24_139 + crew_25_140 + crew_25_141
                + crew_26_142 + crew_26_143 + crew_27_144 + crew_27_145
                + crew_28_146 + crew_28_147 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153 >= 1
 day_3_route_4: crew_5_8 + crew_5_9 + crew_6_10 + crew_6_11 + crew_7_12
                + crew_8_13 + crew_19_32 + crew_19_33 + crew_20_34 + crew_20_35
                + crew_21_36 + crew_21_37 + crew_22_38 + crew_22_39
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43 + crew_5_56
                + crew_5_57 + crew_6_58 + crew_6_59 + crew_7_60 + crew_8_61
                + crew_19_80 + crew_19_81 + crew_20_82 + crew_20_83
                + crew_21_84 + crew_21_85 + crew_22_86 + crew_22_87
                + crew_23_88 + crew_24_89 + crew_25_90 + crew_26_91
                + crew_5_104 + crew_5_105 + crew_6_106 + crew_6_107
                + crew_7_108 + crew_8_109 + crew_23_136 + crew_23_137
                + crew_24_138 + crew_24_139 + crew_25_140 + crew_25_141
                + crew_26_142 + crew_26_143 + crew_27_144 + crew_27_145
                + crew_28_146 + crew_28_147 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_3_164 + crew_3_165 + crew_4_166 + crew_16_188
                + crew_16_189 + crew_17_190 + crew_17_191 + crew_18_192
                + crew_18_193 + crew_19_194 + crew_19_195 + crew_20_196
                + crew_20_197 + crew_21_198 + crew_22_199 + crew_23_200
                + crew_24_201 + crew_25_202 >= 1
 day_3_route_5: crew_5_8 + crew_5_9 + crew_6_10 + crew_6_11 + crew_7_12
                + crew_8_13 + crew_19_32 + crew_19_33 + crew_20_34 + crew_20_35
                + crew_21_36 + crew_21_37 + crew_22_38 + crew_22_39
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43 + crew_5_56
                + crew_5_57 + crew_6_58 + crew_6_59 + crew_7_60 + crew_8_61
                + crew_19_80 + crew_19_81 + crew_20_82 + crew_20_83
                + crew_21_84 + crew_21_85 + crew_22_86 + crew_22_87
                + crew_23_88 + crew_24_89 + crew_25_90 + crew_26_91
                + crew_5_104 + crew_5_105 + crew_6_106 + crew_6_107
                + crew_7_108 + crew_8_109 + crew_23_136 + crew_23_137
                + crew_24_138 + crew_24_139 + crew_25_140 + crew_25_141
                + crew_26_142 + crew_26_143 + crew_27_144 + crew_27_145
                + crew_28_146 + crew_28_147 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_3_164 + crew_3_165 + crew_4_166 + crew_16_188
                + crew_16_189 + crew_17_190 + crew_17_191 + crew_18_192
                + crew_18_193 + crew_19_194 + crew_19_195 + crew_20_196
                + crew_20_197 + crew_21_198 + crew_22_199 + crew_23_200
                + crew_24_201 + crew_25_202 + crew_3_212 + crew_3_213
                + crew_4_214 + crew_16_236 + crew_16_237 + crew_17_238
                + crew_17_239 + crew_18_240 + crew_18_241 + crew_19_242
                + crew_19_243 + crew_20_244 + crew_20_245 + crew_21_246
                + crew_22_247 + crew_23_248 + crew_24_249 + crew_25_250 >= 1
 day_3_route_6: crew_5_8 + crew_5_9 + crew_6_10 + crew_6_11 + crew_7_12
                + crew_8_13 + crew_19_32 + crew_19_33 + crew_20_34 + crew_20_35
                + crew_21_36 + crew_21_37 + crew_22_38 + crew_22_39
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43 + crew_5_56
                + crew_5_57 + crew_6_58 + crew_6_59 + crew_7_60 + crew_8_61
                + crew_19_80 + crew_19_81 + crew_20_82 + crew_20_83
                + crew_21_84 + crew_21_85 + crew_22_86 + crew_22_87
                + crew_23_88 + crew_24_89 + crew_25_90 + crew_26_91
                + crew_5_104 + crew_5_105 + crew_6_106 + crew_6_107
                + crew_7_108 + crew_8_109 + crew_23_136 + crew_23_137
                + crew_24_138 + crew_24_139 + crew_25_140 + crew_25_141
                + crew_26_142 + crew_26_143 + crew_27_144 + crew_27_145
                + crew_28_146 + crew_28_147 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_3_164 + crew_3_165 + crew_4_166 + crew_16_188
                + crew_16_189 + crew_17_190 + crew_17_191 + crew_18_192
                + crew_18_193 + crew_19_194 + crew_19_195 + crew_20_196
                + crew_20_197 + crew_21_198 + crew_22_199 + crew_23_200
                + crew_24_201 + crew_25_202 + crew_3_212 + crew_3_213
                + crew_4_214 + crew_16_236 + crew_16_237 + crew_17_238
                + crew_17_239 + crew_18_240 + crew_18_241 + crew_19_242
                + crew_19_243 + crew_20_244 + crew_20_245 + crew_21_246
                + crew_22_247 + crew_23_248 + crew_24_249 + crew_25_250
                + crew_5_260 + crew_6_261 + crew_7_262 + crew_8_263
                + crew_19_274 + crew_20_275 + crew_21_276 + crew_22_277
                + crew_23_278 + crew_24_279 + crew_25_280 + crew_26_281 >= 1
 day_3_route_7: crew_5_8 + crew_5_9 + crew_6_10 + crew_6_11 + crew_7_12
                + crew_8_13 + crew_19_32 + crew_19_33 + crew_20_34 + crew_20_35
                + crew_21_36 + crew_21_37 + crew_22_38 + crew_22_39
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43 + crew_5_56
                + crew_5_57 + crew_6_58 + crew_6_59 + crew_7_60 + crew_8_61
                + crew_19_80 + crew_19_81 + crew_20_82 + crew_20_83
                + crew_21_84 + crew_21_85 + crew_22_86 + crew_22_87
                + crew_23_88 + crew_24_89 + crew_25_90 + crew_26_91
                + crew_5_104 + crew_5_105 + crew_6_106 + crew_6_107
                + crew_7_108 + crew_8_109 + crew_23_136 + crew_23_137
                + crew_24_138 + crew_24_139 + crew_25_140 + crew_25_141
                + crew_26_142 + crew_26_143 + crew_27_144 + crew_27_145
                + crew_28_146 + crew_28_147 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_3_164 + crew_3_165 + crew_4_166 + crew_16_188
                + crew_16_189 + crew_17_190 + crew_17_191 + crew_18_192
                + crew_18_193 + crew_19_194 + crew_19_195 + crew_20_196
                + crew_20_197 + crew_21_198 + crew_22_199 + crew_23_200
                + crew_24_201 + crew_25_202 + crew_3_212 + crew_3_213
                + crew_4_214 + crew_16_236 + crew_16_237 + crew_17_238
                + crew_17_239 + crew_18_240 + crew_18_241 + crew_19_242
                + crew_19_243 + crew_20_244 + crew_20_245 + crew_21_246
                + crew_22_247 + crew_23_248 + crew_24_249 + crew_25_250
                + crew_5_260 + crew_6_261 + crew_7_262 + crew_8_263
                + crew_19_274 + crew_20_275 + crew_21_276 + crew_22_277
                + crew_23_278 + crew_24_279 + crew_25_280 + crew_26_281
                + crew_5_294 + crew_5_295 + crew_6_296 + crew_6_297
                + crew_7_298 + crew_8_299 + crew_19_318 + crew_19_319
                + crew_20_320 + crew_20_321 + crew_21_322 + crew_21_323
                + crew_22_324 + crew_22_325 + crew_23_326 + crew_24_327
                + crew_25_328 + crew_26_329 >= 1
 day_4_route_1: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8
                + crew_6_10 + crew_7_12 + crew_8_13 + crew_9_14 + crew_10_15
                + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22
                + crew_15_24 + crew_16_26 + crew_17_28 + crew_18_30
                + crew_19_32 + crew_20_34 + crew_21_36 + crew_22_38
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43
                + crew_27_44 + crew_28_45 + crew_29_46 + crew_30_47 >= 1
 day_4_route_2: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8
                + crew_6_10 + crew_7_12 + crew_8_13 + crew_9_14 + crew_10_15
                + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22
                + crew_15_24 + crew_16_26 + crew_17_28 + crew_18_30
                + crew_19_32 + crew_20_34 + crew_21_36 + crew_22_38
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43
                + crew_27_44 + crew_28_45 + crew_29_46 + crew_30_47 + crew_1_48
                + crew_2_50 + crew_3_52 + crew_4_54 + crew_5_56 + crew_6_58
                + crew_7_60 + crew_8_61 + crew_9_62 + crew_10_63 + crew_11_64
                + crew_12_66 + crew_13_68 + crew_14_70 + crew_15_72
                + crew_16_74 + crew_17_76 + crew_18_78 + crew_19_80
                + crew_20_82 + crew_21_84 + crew_22_86 + crew_23_88
                + crew_24_89 + crew_25_90 + crew_26_91 + crew_27_92
                + crew_28_93 + crew_29_94 + crew_30_95 >= 1
 day_4_route_3: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8
                + crew_6_10 + crew_7_12 + crew_8_13 + crew_9_14 + crew_10_15
                + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22
                + crew_15_24 + crew_16_26 + crew_17_28 + crew_18_30
                + crew_19_32 + crew_20_34 + crew_21_36 + crew_22_38
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43
                + crew_27_44 + crew_28_45 + crew_29_46 + crew_30_47 + crew_1_48
                + crew_2_50 + crew_3_52 + crew_4_54 + crew_5_56 + crew_6_58
                + crew_7_60 + crew_8_61 + crew_9_62 + crew_10_63 + crew_11_64
                + crew_12_66 + crew_13_68 + crew_14_70 + crew_15_72
                + crew_16_74 + crew_17_76 + crew_18_78 + crew_19_80
                + crew_20_82 + crew_21_84 + crew_22_86 + crew_23_88
                + crew_24_89 + crew_25_90 + crew_26_91 + crew_27_92
                + crew_28_93 + crew_29_94 + crew_30_95 + crew_1_96 + crew_2_98
                + crew_3_100 + crew_4_102 + crew_5_104 + crew_6_106
                + crew_7_108 + crew_8_109 + crew_9_110 + crew_10_111
                + crew_11_112 + crew_12_114 + crew_13_116 + crew_14_118
                + crew_15_120 + crew_16_122 + crew_17_124 + crew_18_126
                + crew_19_128 + crew_20_130 + crew_21_132 + crew_22_134
                + crew_23_136 + crew_24_138 + crew_25_140 + crew_26_142
                + crew_27_144 + crew_28_146 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_35_154 + crew_36_155 + crew_37_156 + crew_38_157
                + crew_39_158 + crew_40_159 >= 1
 day_4_route_4: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8
                + crew_6_10 + crew_7_12 + crew_8_13 + crew_9_14 + crew_10_15
                + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22
                + crew_15_24 + crew_16_26 + crew_17_28 + crew_18_30
                + crew_19_32 + crew_20_34 + crew_21_36 + crew_22_38
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43
                + crew_27_44 + crew_28_45 + crew_29_46 + crew_30_47 + crew_1_48
                + crew_2_50 + crew_3_52 + crew_4_54 + crew_5_56 + crew_6_58
                + crew_7_60 + crew_8_61 + crew_9_62 + crew_10_63 + crew_11_64
                + crew_12_66 + crew_13_68 + crew_14_70 + crew_15_72
                + crew_16_74 + crew_17_76 + crew_18_78 + crew_19_80
                + crew_20_82 + crew_21_84 + crew_22_86 + crew_23_88
                + crew_24_89 + crew_25_90 + crew_26_91 + crew_27_92
                + crew_28_93 + crew_29_94 + crew_30_95 + crew_1_96 + crew_2_98
                + crew_3_100 + crew_4_102 + crew_5_104 + crew_6_106
                + crew_7_108 + crew_8_109 + crew_9_110 + crew_10_111
                + crew_11_112 + crew_12_114 + crew_13_116 + crew_14_118
                + crew_15_120 + crew_16_122 + crew_17_124 + crew_18_126
                + crew_19_128 + crew_20_130 + crew_21_132 + crew_22_134
                + crew_23_136 + crew_24_138 + crew_25_140 + crew_26_142
                + crew_27_144 + crew_28_146 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_35_154 + crew_36_155 + crew_37_156 + crew_38_157
                + crew_39_158 + crew_40_159 + crew_1_160 + crew_2_162
                + crew_3_164 + crew_4_166 + crew_5_167 + crew_6_168
                + crew_7_170 + crew_8_172 + crew_9_174 + crew_10_176
                + crew_11_178 + crew_12_180 + crew_13_182 + crew_14_184
                + crew_15_186 + crew_16_188 + crew_17_190 + crew_18_192
                + crew_19_194 + crew_20_196 + crew_21_198 + crew_22_199
                + crew_23_200 + crew_24_201 + crew_25_202 + crew_26_203
                + crew_27_204 + crew_28_205 + crew_29_206 + crew_30_207 >= 1
 day_4_route_5: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8
                + crew_6_10 + crew_7_12 + crew_8_13 + crew_9_14 + crew_10_15
                + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22
                + crew_15_24 + crew_16_26 + crew_17_28 + crew_18_30
                + crew_19_32 + crew_20_34 + crew_21_36 + crew_22_38
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43
                + crew_27_44 + crew_28_45 + crew_29_46 + crew_30_47 + crew_1_48
                + crew_2_50 + crew_3_52 + crew_4_54 + crew_5_56 + crew_6_58
                + crew_7_60 + crew_8_61 + crew_9_62 + crew_10_63 + crew_11_64
                + crew_12_66 + crew_13_68 + crew_14_70 + crew_15_72
                + crew_16_74 + crew_17_76 + crew_18_78 + crew_19_80
                + crew_20_82 + crew_21_84 + crew_22_86 + crew_23_88
                + crew_24_89 + crew_25_90 + crew_26_91 + crew_27_92
                + crew_28_93 + crew_29_94 + crew_30_95 + crew_1_96 + crew_2_98
                + crew_3_100 + crew_4_102 + crew_5_104 + crew_6_106
                + crew_7_108 + crew_8_109 + crew_9_110 + crew_10_111
                + crew_11_112 + crew_12_114 + crew_13_116 + crew_14_118
                + crew_15_120 + crew_16_122 + crew_17_124 + crew_18_126
                + crew_19_128 + crew_20_130 + crew_21_132 + crew_22_134
                + crew_23_136 + crew_24_138 + crew_25_140 + crew_26_142
                + crew_27_144 + crew_28_146 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_35_154 + crew_36_155 + crew_37_156 + crew_38_157
                + crew_39_158 + crew_40_159 + crew_1_160 + crew_2_162
                + crew_3_164 + crew_4_166 + crew_5_167 + crew_6_168
                + crew_7_170 + crew_8_172 + crew_9_174 + crew_10_176
                + crew_11_178 + crew_12_180 + crew_13_182 + crew_14_184
                + crew_15_186 + crew_16_188 + crew_17_190 + crew_18_192
                + crew_19_194 + crew_20_196 + crew_21_198 + crew_22_199
                + crew_23_200 + crew_24_201 + crew_25_202 + crew_26_203
                + crew_27_204 + crew_28_205 + crew_29_206 + crew_30_207
                + crew_1_208 + crew_2_210 + crew_3_212 + crew_4_214
                + crew_5_215 + crew_6_216 + crew_7_218 + crew_8_220
                + crew_9_222 + crew_10_224 + crew_11_226 + crew_12_228
                + crew_13_230 + crew_14_232 + crew_15_234 + crew_16_236
                + crew_17_238 + crew_18_240 + crew_19_242 + crew_20_244
                + crew_21_246 + crew_22_247 + crew_23_248 + crew_24_249
                + crew_25_250 + crew_26_251 + crew_27_252 + crew_28_253
                + crew_29_254 + crew_30_255 >= 1
 day_4_route_6: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8
                + crew_6_10 + crew_7_12 + crew_8_13 + crew_9_14 + crew_10_15
                + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22
                + crew_15_24 + crew_16_26 + crew_17_28 + crew_18_30
                + crew_19_32 + crew_20_34 + crew_21_36 + crew_22_38
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43
                + crew_27_44 + crew_28_45 + crew_29_46 + crew_30_47 + crew_1_48
                + crew_2_50 + crew_3_52 + crew_4_54 + crew_5_56 + crew_6_58
                + crew_7_60 + crew_8_61 + crew_9_62 + crew_10_63 + crew_11_64
                + crew_12_66 + crew_13_68 + crew_14_70 + crew_15_72
                + crew_16_74 + crew_17_76 + crew_18_78 + crew_19_80
                + crew_20_82 + crew_21_84 + crew_22_86 + crew_23_88
                + crew_24_89 + crew_25_90 + crew_26_91 + crew_27_92
                + crew_28_93 + crew_29_94 + crew_30_95 + crew_1_96 + crew_2_98
                + crew_3_100 + crew_4_102 + crew_5_104 + crew_6_106
                + crew_7_108 + crew_8_109 + crew_9_110 + crew_10_111
                + crew_11_112 + crew_12_114 + crew_13_116 + crew_14_118
                + crew_15_120 + crew_16_122 + crew_17_124 + crew_18_126
                + crew_19_128 + crew_20_130 + crew_21_132 + crew_22_134
                + crew_23_136 + crew_24_138 + crew_25_140 + crew_26_142
                + crew_27_144 + crew_28_146 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_35_154 + crew_36_155 + crew_37_156 + crew_38_157
                + crew_39_158 + crew_40_159 + crew_1_160 + crew_2_162
                + crew_3_164 + crew_4_166 + crew_5_167 + crew_6_168
                + crew_7_170 + crew_8_172 + crew_9_174 + crew_10_176
                + crew_11_178 + crew_12_180 + crew_13_182 + crew_14_184
                + crew_15_186 + crew_16_188 + crew_17_190 + crew_18_192
                + crew_19_194 + crew_20_196 + crew_21_198 + crew_22_199
                + crew_23_200 + crew_24_201 + crew_25_202 + crew_26_203
                + crew_27_204 + crew_28_205 + crew_29_206 + crew_30_207
                + crew_1_208 + crew_2_210 + crew_3_212 + crew_4_214
                + crew_5_215 + crew_6_216 + crew_7_218 + crew_8_220
                + crew_9_222 + crew_10_224 + crew_11_226 + crew_12_228
                + crew_13_230 + crew_14_232 + crew_15_234 + crew_16_236
                + crew_17_238 + crew_18_240 + crew_19_242 + crew_20_244
                + crew_21_246 + crew_22_247 + crew_23_248 + crew_24_249
                + crew_25_250 + crew_26_251 + crew_27_252 + crew_28_253
                + crew_29_254 + crew_30_255 + crew_7_262 + crew_8_263
                + crew_9_264 + crew_10_265 + crew_23_278 + crew_24_279
                + crew_25_280 + crew_26_281 + crew_27_282 + crew_28_283
                + crew_29_284 + crew_30_285 >= 1
 day_4_route_7: crew_1_0 + crew_2_2 + crew_3_4 + crew_4_6 + crew_5_8
                + crew_6_10 + crew_7_12 + crew_8_13 + crew_9_14 + crew_10_15
                + crew_11_16 + crew_12_18 + crew_13_20 + crew_14_22
                + crew_15_24 + crew_16_26 + crew_17_28 + crew_18_30
                + crew_19_32 + crew_20_34 + crew_21_36 + crew_22_38
                + crew_23_40 + crew_24_41 + crew_25_42 + crew_26_43
                + crew_27_44 + crew_28_45 + crew_29_46 + crew_30_47 + crew_1_48
                + crew_2_50 + crew_3_52 + crew_4_54 + crew_5_56 + crew_6_58
                + crew_7_60 + crew_8_61 + crew_9_62 + crew_10_63 + crew_11_64
                + crew_12_66 + crew_13_68 + crew_14_70 + crew_15_72
                + crew_16_74 + crew_17_76 + crew_18_78 + crew_19_80
                + crew_20_82 + crew_21_84 + crew_22_86 + crew_23_88
                + crew_24_89 + crew_25_90 + crew_26_91 + crew_27_92
                + crew_28_93 + crew_29_94 + crew_30_95 + crew_1_96 + crew_2_98
                + crew_3_100 + crew_4_102 + crew_5_104 + crew_6_106
                + crew_7_108 + crew_8_109 + crew_9_110 + crew_10_111
                + crew_11_112 + crew_12_114 + crew_13_116 + crew_14_118
                + crew_15_120 + crew_16_122 + crew_17_124 + crew_18_126
                + crew_19_128 + crew_20_130 + crew_21_132 + crew_22_134
                + crew_23_136 + crew_24_138 + crew_25_140 + crew_26_142
                + crew_27_144 + crew_28_146 + crew_29_148 + crew_30_149
                + crew_31_150 + crew_32_151 + crew_33_152 + crew_34_153
                + crew_35_154 + crew_36_155 + crew_37_156 + crew_38_157
                + crew_39_158 + crew_40_159 + crew_1_160 + crew_2_162
                + crew_3_164 + crew_4_166 + crew_5_167 + crew_6_168
                + crew_7_170 + crew_8_172 + crew_9_174 + crew_10_176
                + crew_11_178 + crew_12_180 + crew_13_182 + crew_14_184
                + crew_15_186 + crew_16_188 + crew_17_190 + crew_18_192
                + crew_19_194 + crew_20_196 + crew_21_198 + crew_22_199
                + crew_23_200 + crew_24_201 + crew_25_202 + crew_26_203
                + crew_27_204 + crew_28_205 + crew_29_206 + crew_30_207
                + crew_1_208 + crew_2_210 + crew_3_212 + crew_4_214
                + crew_5_215 + crew_6_216 + crew_7_218 + crew_8_220
                + crew_9_222 + crew_10_224 + crew_11_226 + crew_12_228
                + crew_13_230 + crew_14_232 + crew_15_234 + crew_16_236
                + crew_17_238 + crew_18_240 + crew_19_242 + crew_20_244
                + crew_21_246 + crew_22_247 + crew_23_248 + crew_24_249
                + crew_25_250 + crew_26_251 + crew_27_252 + crew_28_253
                + crew_29_254 + crew_30_255 + crew_7_262 + crew_8_263
                + crew_9_264 + crew_10_265 + crew_23_278 + crew_24_279
                + crew_25_280 + crew_26_281 + crew_27_282 + crew_28_283
                + crew_29_284 + crew_30_285 + crew_1_286 + crew_2_288
                + crew_3_290 + crew_4_292 + crew_5_294 + crew_6_296
                + crew_7_298 + crew_8_299 + crew_9_300 + crew_10_301
                + crew_11_302 + crew_12_304 + crew_13_306 + crew_14_308
                + crew_15_310 + crew_16_312 + crew_17_314 + crew_18_316
                + crew_19_318 + crew_20_320 + crew_21_322 + crew_22_324
                + crew_23_326 + crew_24_327 + crew_25_328 + crew_26_329
                + crew_27_330 + crew_28_331 + crew_29_332 + crew_30_333 >= 1
 c71:           crew_1_0 + crew_1_1 + crew_1_48 + crew_1_49 + crew_1_96
                + crew_1_97 + crew_1_160 + crew_1_161 + crew_1_208 + crew_1_209
                + crew_1_256 + crew_1_286 + crew_1_287  = 1
 c73:           crew_2_2 + crew_2_3 + crew_2_50 + crew_2_51 + crew_2_98
                + crew_2_99 + crew_2_162 + crew_2_163 + crew_2_210 + crew_2_211
                + crew_2_257 + crew_2_288 + crew_2_289  = 1
 c75:           crew_3_4 + crew_3_5 + crew_3_52 + crew_3_53 + crew_3_100
                + crew_3_101 + crew_3_164 + crew_3_165 + crew_3_212
                + crew_3_213 + crew_3_258 + crew_3_290 + crew_3_291  = 1
 c77:           crew_4_6 + crew_4_7 + crew_4_54 + crew_4_55 + crew_4_102
                + crew_4_103 + crew_4_166 + crew_4_214 + crew_4_259
                + crew_4_292 + crew_4_293  = 1
 c79:           crew_5_8 + crew_5_9 + crew_5_56 + crew_5_57 + crew_5_104
                + crew_5_105 + crew_5_167 + crew_5_215 + crew_5_260
                + crew_5_294 + crew_5_295  = 1
 c81:           crew_6_10 + crew_6_11 + crew_6_58 + crew_6_59 + crew_6_106
                + crew_6_107 + crew_6_168 + crew_6_169 + crew_6_216
                + crew_6_217 + crew_6_261 + crew_6_296 + crew_6_297  = 1
 c83:           crew_7_12 + crew_7_60 + crew_7_108 + crew_7_170 + crew_7_171
                + crew_7_218 + crew_7_219 + crew_7_262 + crew_7_298  = 1
 c85:           crew_8_13 + crew_8_61 + crew_8_109 + crew_8_172 + crew_8_173
                + crew_8_220 + crew_8_221 + crew_8_263 + crew_8_299  = 1
 c87:           crew_9_14 + crew_9_62 + crew_9_110 + crew_9_174 + crew_9_175
                + crew_9_222 + crew_9_223 + crew_9_264 + crew_9_300  = 1
 c89:           crew_10_15 + crew_10_63 + crew_10_111 + crew_10_176
                + crew_10_177 + crew_10_224 + crew_10_225 + crew_10_265
                + crew_10_301  = 1
 c91:           crew_11_16 + crew_11_17 + crew_11_64 + crew_11_65 + crew_11_112
                + crew_11_113 + crew_11_178 + crew_11_179 + crew_11_226
                + crew_11_227 + crew_11_266 + crew_11_302 + crew_11_303  = 1
 c93:           crew_12_18 + crew_12_19 + crew_12_66 + crew_12_67 + crew_12_114
                + crew_12_115 + crew_12_180 + crew_12_181 + crew_12_228
                + crew_12_229 + crew_12_267 + crew_12_304 + crew_12_305  = 1
 c95:           crew_13_20 + crew_13_21 + crew_13_68 + crew_13_69 + crew_13_116
                + crew_13_117 + crew_13_182 + crew_13_183 + crew_13_230
                + crew_13_231 + crew_13_268 + crew_13_306 + crew_13_307  = 1
 c97:           crew_14_22 + crew_14_23 + crew_14_70 + crew_14_71 + crew_14_118
                + crew_14_119 + crew_14_184 + crew_14_185 + crew_14_232
                + crew_14_233 + crew_14_269 + crew_14_308 + crew_14_309  = 1
 c99:           crew_15_24 + crew_15_25 + crew_15_72 + crew_15_73 + crew_15_120
                + crew_15_121 + crew_15_186 + crew_15_187 + crew_15_234
                + crew_15_235 + crew_15_270 + crew_15_310 + crew_15_311  = 1
 c101:          crew_16_26 + crew_16_27 + crew_16_74 + crew_16_75 + crew_16_122
                + crew_16_123 + crew_16_188 + crew_16_189 + crew_16_236
                + crew_16_237 + crew_16_271 + crew_16_312 + crew_16_313  = 1
 c103:          crew_17_28 + crew_17_29 + crew_17_76 + crew_17_77 + crew_17_124
                + crew_17_125 + crew_17_190 + crew_17_191 + crew_17_238
                + crew_17_239 + crew_17_272 + crew_17_314 + crew_17_315  = 1
 c105:          crew_18_30 + crew_18_31 + crew_18_78 + crew_18_79 + crew_18_126
                + crew_18_127 + crew_18_192 + crew_18_193 + crew_18_240
                + crew_18_241 + crew_18_273 + crew_18_316 + crew_18_317  = 1
 c107:          crew_19_32 + crew_19_33 + crew_19_80 + crew_19_81 + crew_19_128
                + crew_19_129 + crew_19_194 + crew_19_195 + crew_19_242
                + crew_19_243 + crew_19_274 + crew_19_318 + crew_19_319  = 1
 c109:          crew_20_34 + crew_20_35 + crew_20_82 + crew_20_83 + crew_20_130
                + crew_20_131 + crew_20_196 + crew_20_197 + crew_20_244
                + crew_20_245 + crew_20_275 + crew_20_320 + crew_20_321  = 1
 c111:          crew_21_36 + crew_21_37 + crew_21_84 + crew_21_85 + crew_21_132
                + crew_21_133 + crew_21_198 + crew_21_246 + crew_21_276
                + crew_21_322 + crew_21_323  = 1
 c113:          crew_22_38 + crew_22_39 + crew_22_86 + crew_22_87 + crew_22_134
                + crew_22_135 + crew_22_199 + crew_22_247 + crew_22_277
                + crew_22_324 + crew_22_325  = 1
 c115:          crew_23_40 + crew_23_88 + crew_23_136 + crew_23_137
                + crew_23_200 + crew_23_248 + crew_23_278 + crew_23_326  = 1
 c117:          crew_24_41 + crew_24_89 + crew_24_138 + crew_24_139
                + crew_24_201 + crew_24_249 + crew_24_279 + crew_24_327  = 1
 c119:          crew_25_42 + crew_25_90 + crew_25_140 + crew_25_141
                + crew_25_202 + crew_25_250 + crew_25_280 + crew_25_328  = 1
 c121:          crew_26_43 + crew_26_91 + crew_26_142 + crew_26_143
                + crew_26_203 + crew_26_251 + crew_26_281 + crew_26_329  = 1
 c123:          crew_27_44 + crew_27_92 + crew_27_144 + crew_27_145
                + crew_27_204 + crew_27_252 + crew_27_282 + crew_27_330  = 1
 c125:          crew_28_45 + crew_28_93 + crew_28_146 + crew_28_147
                + crew_28_205 + crew_28_253 + crew_28_283 + crew_28_331  = 1
 c127:          crew_29_46 + crew_29_94 + crew_29_148 + crew_29_206
                + crew_29_254 + crew_29_284 + crew_29_332  = 1
 c129:          crew_30_47 + crew_30_95 + crew_30_149 + crew_30_207
                + crew_30_255 + crew_30_285 + crew_30_333  = 1
 c131:          crew_31_150  = 1
 c133:          crew_32_151  = 1
 c135:          crew_33_152  = 1
 c137:          crew_34_153  = 1
 c139:          crew_35_154  = 1
 c141:          crew_36_155  = 1
 c143:          crew_37_156  = 1
 c145:          crew_38_157  = 1
 c147:          crew_39_158  = 1
 c149:          crew_40_159  = 1
Bounds
 0 <= crew_1_0 <= 1
 0 <= crew_1_1 <= 1
 0 <= crew_2_2 <= 1
 0 <= crew_2_3 <= 1
 0 <= crew_3_4 <= 1
 0 <= crew_3_5 <= 1
 0 <= crew_4_6 <= 1
 0 <= crew_4_7 <= 1
 0 <= crew_5_8 <= 1
 0 <= crew_5_9 <= 1
 0 <= crew_6_10 <= 1
 0 <= crew_6_11 <= 1
 0 <= crew_7_12 <= 1
 0 <= crew_8_13 <= 1
 0 <= crew_9_14 <= 1
 0 <= crew_10_15 <= 1
 0 <= crew_11_16 <= 1
 0 <= crew_11_17 <= 1
 0 <= crew_12_18 <= 1
 0 <= crew_12_19 <= 1
 0 <= crew_13_20 <= 1
 0 <= crew_13_21 <= 1
 0 <= crew_14_22 <= 1
 0 <= crew_14_23 <= 1
 0 <= crew_15_24 <= 1
 0 <= crew_15_25 <= 1
 0 <= crew_16_26 <= 1
 0 <= crew_16_27 <= 1
 0 <= crew_17_28 <= 1
 0 <= crew_17_29 <= 1
 0 <= crew_18_30 <= 1
 0 <= crew_18_31 <= 1
 0 <= crew_19_32 <= 1
 0 <= crew_19_33 <= 1
 0 <= crew_20_34 <= 1
 0 <= crew_20_35 <= 1
 0 <= crew_21_36 <= 1
 0 <= crew_21_37 <= 1
 0 <= crew_22_38 <= 1
 0 <= crew_22_39 <= 1
 0 <= crew_23_40 <= 1
 0 <= crew_24_41 <= 1
 0 <= crew_25_42 <= 1
 0 <= crew_26_43 <= 1
 0 <= crew_27_44 <= 1
 0 <= crew_28_45 <= 1
 0 <= crew_29_46 <= 1
 0 <= crew_30_47 <= 1
 0 <= crew_1_48 <= 1
 0 <= crew_1_49 <= 1
 0 <= crew_2_50 <= 1
 0 <= crew_2_51 <= 1
 0 <= crew_3_52 <= 1
 0 <= crew_3_53 <= 1
 0 <= crew_4_54 <= 1
 0 <= crew_4_55 <= 1
 0 <= crew_5_56 <= 1
 0 <= crew_5_57 <= 1
 0 <= crew_6_58 <= 1
 0 <= crew_6_59 <= 1
 0 <= crew_7_60 <= 1
 0 <= crew_8_61 <= 1
 0 <= crew_9_62 <= 1
 0 <= crew_10_63 <= 1
 0 <= crew_11_64 <= 1
 0 <= crew_11_65 <= 1
 0 <= crew_12_66 <= 1
 0 <= crew_12_67 <= 1
 0 <= crew_13_68 <= 1
 0 <= crew_13_69 <= 1
 0 <= crew_14_70 <= 1
 0 <= crew_14_71 <= 1
 0 <= crew_15_72 <= 1
 0 <= crew_15_73 <= 1
 0 <= crew_16_74 <= 1
 0 <= crew_16_75 <= 1
 0 <= crew_17_76 <= 1
 0 <= crew_17_77 <= 1
 0 <= crew_18_78 <= 1
 0 <= crew_18_79 <= 1
 0 <= crew_19_80 <= 1
 0 <= crew_19_81 <= 1
 0 <= crew_20_82 <= 1
 0 <= crew_20_83 <= 1
 0 <= crew_21_84 <= 1
 0 <= crew_21_85 <= 1
 0 <= crew_22_86 <= 1
 0 <= crew_22_87 <= 1
 0 <= crew_23_88 <= 1
 0 <= crew_24_89 <= 1
 0 <= crew_25_90 <= 1
 0 <= crew_26_91 <= 1
 0 <= crew_27_92 <= 1
 0 <= crew_28_93 <= 1
 0 <= crew_29_94 <= 1
 0 <= crew_30_95 <= 1
 0 <= crew_1_96 <= 1
 0 <= crew_1_97 <= 1
 0 <= crew_2_98 <= 1
 0 <= crew_2_99 <= 1
 0 <= crew_3_100 <= 1
 0 <= crew_3_101 <= 1
 0 <= crew_4_102 <= 1
 0 <= crew_4_103 <= 1
 0 <= crew_5_104 <= 1
 0 <= crew_5_105 <= 1
 0 <= crew_6_106 <= 1
 0 <= crew_6_107 <= 1
 0 <= crew_7_108 <= 1
 0 <= crew_8_109 <= 1
 0 <= crew_9_110 <= 1
 0 <= crew_10_111 <= 1
 0 <= crew_11_112 <= 1
 0 <= crew_11_113 <= 1
 0 <= crew_12_114 <= 1
 0 <= crew_12_115 <= 1
 0 <= crew_13_116 <= 1
 0 <= crew_13_117 <= 1
 0 <= crew_14_118 <= 1
 0 <= crew_14_119 <= 1
 0 <= crew_15_120 <= 1
 0 <= crew_15_121 <= 1
 0 <= crew_16_122 <= 1
 0 <= crew_16_123 <= 1
 0 <= crew_17_124 <= 1
 0 <= crew_17_125 <= 1
 0 <= crew_18_126 <= 1
 0 <= crew_18_127 <= 1
 0 <= crew_19_128 <= 1
 0 <= crew_19_129 <= 1
 0 <= crew_20_130 <= 1
 0 <= crew_20_131 <= 1
 0 <= crew_21_132 <= 1
 0 <= crew_21_133 <= 1
 0 <= crew_22_134 <= 1
 0 <= crew_22_135 <= 1
 0 <= crew_23_136 <= 1
 0 <= crew_23_137 <= 1
 0 <= crew_24_138 <= 1
 0 <= crew_24_139 <= 1
 0 <= crew_25_140 <= 1
 0 <= crew_25_141 <= 1
 0 <= crew_26_142 <= 1
 0 <= crew_26_143 <= 1
 0 <= crew_27_144 <= 1
 0 <= crew_27_145 <= 1
 0 <= crew_28_146 <= 1
 0 <= crew_28_147 <= 1
 0 <= crew_29_148 <= 1
 0 <= crew_30_149 <= 1
 0 <= crew_31_150 <= 1
 0 <= crew_32_151 <= 1
 0 <= crew_33_152 <= 1
 0 <= crew_34_153 <= 1
 0 <= crew_35_154 <= 1
 0 <= crew_36_155 <= 1
 0 <= crew_37_156 <= 1
 0 <= crew_38_157 <= 1
 0 <= crew_39_158 <= 1
 0 <= crew_40_159 <= 1
 0 <= crew_1_160 <= 1
 0 <= crew_1_161 <= 1
 0 <= crew_2_162 <= 1
 0 <= crew_2_163 <= 1
 0 <= crew_3_164 <= 1
 0 <= crew_3_165 <= 1
 0 <= crew_4_166 <= 1
 0 <= crew_5_167 <= 1
 0 <= crew_6_168 <= 1
 0 <= crew_6_169 <= 1
 0 <= crew_7_170 <= 1
 0 <= crew_7_171 <= 1
 0 <= crew_8_172 <= 1
 0 <= crew_8_173 <= 1
 0 <= crew_9_174 <= 1
 0 <= crew_9_175 <= 1
 0 <= crew_10_176 <= 1
 0 <= crew_10_177 <= 1
 0 <= crew_11_178 <= 1
 0 <= crew_11_179 <= 1
 0 <= crew_12_180 <= 1
 0 <= crew_12_181 <= 1
 0 <= crew_13_182 <= 1
 0 <= crew_13_183 <= 1
 0 <= crew_14_184 <= 1
 0 <= crew_14_185 <= 1
 0 <= crew_15_186 <= 1
 0 <= crew_15_187 <= 1
 0 <= crew_16_188 <= 1
 0 <= crew_16_189 <= 1
 0 <= crew_17_190 <= 1
 0 <= crew_17_191 <= 1
 0 <= crew_18_192 <= 1
 0 <= crew_18_193 <= 1
 0 <= crew_19_194 <= 1
 0 <= crew_19_195 <= 1
 0 <= crew_20_196 <= 1
 0 <= crew_20_197 <= 1
 0 <= crew_21_198 <= 1
 0 <= crew_22_199 <= 1
 0 <= crew_23_200 <= 1
 0 <= crew_24_201 <= 1
 0 <= crew_25_202 <= 1
 0 <= crew_26_203 <= 1
 0 <= crew_27_204 <= 1
 0 <= crew_28_205 <= 1
 0 <= crew_29_206 <= 1
 0 <= crew_30_207 <= 1
 0 <= crew_1_208 <= 1
 0 <= crew_1_209 <= 1
 0 <= crew_2_210 <= 1
 0 <= crew_2_211 <= 1
 0 <= crew_3_212 <= 1
 0 <= crew_3_213 <= 1
 0 <= crew_4_214 <= 1
 0 <= crew_5_215 <= 1
 0 <= crew_6_216 <= 1
 0 <= crew_6_217 <= 1
 0 <= crew_7_218 <= 1
 0 <= crew_7_219 <= 1
 0 <= crew_8_220 <= 1
 0 <= crew_8_221 <= 1
 0 <= crew_9_222 <= 1
 0 <= crew_9_223 <= 1
 0 <= crew_10_224 <= 1
 0 <= crew_10_225 <= 1
 0 <= crew_11_226 <= 1
 0 <= crew_11_227 <= 1
 0 <= crew_12_228 <= 1
 0 <= crew_12_229 <= 1
 0 <= crew_13_230 <= 1
 0 <= crew_13_231 <= 1
 0 <= crew_14_232 <= 1
 0 <= crew_14_233 <= 1
 0 <= crew_15_234 <= 1
 0 <= crew_15_235 <= 1
 0 <= crew_16_236 <= 1
 0 <= crew_16_237 <= 1
 0 <= crew_17_238 <= 1
 0 <= crew_17_239 <= 1
 0 <= crew_18_240 <= 1
 0 <= crew_18_241 <= 1
 0 <= crew_19_242 <= 1
 0 <= crew_19_243 <= 1
 0 <= crew_20_244 <= 1
 0 <= crew_20_245 <= 1
 0 <= crew_21_246 <= 1
 0 <= crew_22_247 <= 1
 0 <= crew_23_248 <= 1
 0 <= crew_24_249 <= 1
 0 <= crew_25_250 <= 1
 0 <= crew_26_251 <= 1
 0 <= crew_27_252 <= 1
 0 <= crew_28_253 <= 1
 0 <= crew_29_254 <= 1
 0 <= crew_30_255 <= 1
 0 <= crew_1_256 <= 1
 0 <= crew_2_257 <= 1
 0 <= crew_3_258 <= 1
 0 <= crew_4_259 <= 1
 0 <= crew_5_260 <= 1
 0 <= crew_6_261 <= 1
 0 <= crew_7_262 <= 1
 0 <= crew_8_263 <= 1
 0 <= crew_9_264 <= 1
 0 <= crew_10_265 <= 1
 0 <= crew_11_266 <= 1
 0 <= crew_12_267 <= 1
 0 <= crew_13_268 <= 1
 0 <= crew_14_269 <= 1
 0 <= crew_15_270 <= 1
 0 <= crew_16_271 <= 1
 0 <= crew_17_272 <= 1
 0 <= crew_18_273 <= 1
 0 <= crew_19_274 <= 1
 0 <= crew_20_275 <= 1
 0 <= crew_21_276 <= 1
 0 <= crew_22_277 <= 1
 0 <= crew_23_278 <= 1
 0 <= crew_24_279 <= 1
 0 <= crew_25_280 <= 1
 0 <= crew_26_281 <= 1
 0 <= crew_27_282 <= 1
 0 <= crew_28_283 <= 1
 0 <= crew_29_284 <= 1
 0 <= crew_30_285 <= 1
 0 <= crew_1_286 <= 1
 0 <= crew_1_287 <= 1
 0 <= crew_2_288 <= 1
 0 <= crew_2_289 <= 1
 0 <= crew_3_290 <= 1
 0 <= crew_3_291 <= 1
 0 <= crew_4_292 <= 1
 0 <= crew_4_293 <= 1
 0 <= crew_5_294 <= 1
 0 <= crew_5_295 <= 1
 0 <= crew_6_296 <= 1
 0 <= crew_6_297 <= 1
 0 <= crew_7_298 <= 1
 0 <= crew_8_299 <= 1
 0 <= crew_9_300 <= 1
 0 <= crew_10_301 <= 1
 0 <= crew_11_302 <= 1
 0 <= crew_11_303 <= 1
 0 <= crew_12_304 <= 1
 0 <= crew_12_305 <= 1
 0 <= crew_13_306 <= 1
 0 <= crew_13_307 <= 1
 0 <= crew_14_308 <= 1
 0 <= crew_14_309 <= 1
 0 <= crew_15_310 <= 1
 0 <= crew_15_311 <= 1
 0 <= crew_16_312 <= 1
 0 <= crew_16_313 <= 1
 0 <= crew_17_314 <= 1
 0 <= crew_17_315 <= 1
 0 <= crew_18_316 <= 1
 0 <= crew_18_317 <= 1
 0 <= crew_19_318 <= 1
 0 <= crew_19_319 <= 1
 0 <= crew_20_320 <= 1
 0 <= crew_20_321 <= 1
 0 <= crew_21_322 <= 1
 0 <= crew_21_323 <= 1
 0 <= crew_22_324 <= 1
 0 <= crew_22_325 <= 1
 0 <= crew_23_326 <= 1
 0 <= crew_24_327 <= 1
 0 <= crew_25_328 <= 1
 0 <= crew_26_329 <= 1
 0 <= crew_27_330 <= 1
 0 <= crew_28_331 <= 1
 0 <= crew_29_332 <= 1
 0 <= crew_30_333 <= 1
End
